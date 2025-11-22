/*Ricardo Rodrigo*/
using backend_proyect.Services;
// Remover using de Interfaces si existe

namespace backend_proyect.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            // Registrar directamente sin interfaz
            services.AddScoped<UsuarioService>();
            // O si necesitas registrarlo para inyección, usa:
            // services.AddScoped<UsuarioService>();
            
            // Otros servicios...
            services.AddScoped<AuthService>();
        }
    }
}