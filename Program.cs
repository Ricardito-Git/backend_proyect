//arturo
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using backend_proyect.Models;
using backend_proyect.Services;
using backend_proyect.Services.Interfaces;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configurar Entity Framework con MySQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        connectionString,
        new MySqlServerVersion(new Version(8, 0, 0))
    ));

// Configurar servicios de aplicación
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
// En la sección de servicios, agrega:
builder.Services.AddScoped<IAuthService, AuthService>();
// Configurar Health Checks - VERSION CORREGIDA
builder.Services.AddHealthChecks()
    .AddMySql(connectionString);

// Configurar JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"]))
    };
});

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// ==================== VERIFICACION DE BASE DE DATOS AL INICIAR ====================
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var startupLogger = services.GetRequiredService<ILogger<Program>>();
    
    try
    {
        startupLogger.LogInformation("Verificando conexion a la base de datos Aiven...");
        
        var context = services.GetRequiredService<ApplicationDbContext>();
        
        // 1. Verificar si puede conectar
        var canConnect = await context.Database.CanConnectAsync();
        startupLogger.LogInformation("Puede conectar a la BD? {CanConnect}", canConnect);
        
        if (canConnect)
        {
            // 2. Verificar migraciones
            var pendingMigrations = await context.Database.GetPendingMigrationsAsync();
            var appliedMigrations = await context.Database.GetAppliedMigrationsAsync();
            
            startupLogger.LogInformation("Migraciones aplicadas: {AppliedCount}", appliedMigrations.Count());
            
            if (pendingMigrations.Any())
            {
                startupLogger.LogWarning("Migraciones pendientes: {PendingCount}", pendingMigrations.Count());
                foreach (var migration in pendingMigrations)
                {
                    startupLogger.LogWarning("   - {Migration}", migration);
                }
                
                // Aplicar migraciones automaticamente
                startupLogger.LogInformation("Aplicando migraciones pendientes...");
                await context.Database.MigrateAsync();
                startupLogger.LogInformation("Migraciones aplicadas correctamente");
            }
            else
            {
                startupLogger.LogInformation("No hay migraciones pendientes");
            }
            
            // 3. Verificar datos basicos
            try
            {
                var usuariosCount = await context.Usuarios.CountAsync();
                var perfilesCount = await context.Perfiles.CountAsync();
                var productosCount = await context.Productos.CountAsync();
                var empresasCount = await context.Empresas.CountAsync();
                
                startupLogger.LogInformation("Estadisticas - Usuarios: {UsuariosCount}, Perfiles: {PerfilesCount}, Productos: {ProductosCount}, Empresas: {EmpresasCount}", 
                    usuariosCount, perfilesCount, productosCount, empresasCount);
                
                if (usuariosCount == 0)
                {
                    startupLogger.LogInformation("No hay usuarios en la base de datos");
                }
            }
            catch (Exception queryEx)
            {
                startupLogger.LogWarning("Error en consultas de estadisticas: {ErrorMessage}", queryEx.Message);
            }
            
            startupLogger.LogInformation("Conexion a Aiven MySQL verificada exitosamente");
        }
        else
        {
            startupLogger.LogError("No se puede conectar a la base de datos Aiven");
        }
    }
    catch (Exception ex)
    {
        startupLogger.LogError(ex, "Error critico al conectar con Aiven MySQL");
        startupLogger.LogError("Detalles: {ErrorMessage}", ex.Message);
    }
}

// ==================== CONFIGURACION DEL PIPELINE ====================
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseCors("AllowAll");
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// ==================== ENDPOINTS DE HEALTH CHECK ====================
app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.MapHealthChecks("/health/ready", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

// Endpoint simple de ping
app.MapGet("/api/ping", () => new 
{ 
    message = "API is running", 
    timestamp = DateTime.Now,
    status = "OK",
    database = "Aiven MySQL",
    environment = app.Environment.EnvironmentName
});

// Endpoint especifico para verificar base de datos
app.MapGet("/api/database-check", async (ApplicationDbContext context) =>
{
    try
    {
        var canConnect = await context.Database.CanConnectAsync();
        var usuariosCount = await context.Usuarios.CountAsync();
        var perfilesCount = await context.Perfiles.CountAsync();
        
        return Results.Ok(new
        {
            status = canConnect ? "Connected" : "Disconnected",
            database = "Aiven MySQL",
            timestamp = DateTime.Now,
            statistics = new
            {
                usuarios = usuariosCount,
                perfiles = perfilesCount
            },
            message = canConnect ? "Conexion exitosa a Aiven MySQL" : "No se pudo conectar a la base de datos"
        });
    }
    catch (Exception ex)
    {
        return Results.Problem(
            title: "Error de base de datos",
            detail: ex.Message,
            statusCode: 500
        );
    }
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

var appLogger = app.Services.GetRequiredService<ILogger<Program>>();
appLogger.LogInformation("Aplicacion iniciada correctamente con Aiven MySQL");

app.Run();