//esto solo es para checar si esta correcto con la base de dato y se conecta 
/*
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend_proyect.Models;

namespace backend_proyect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HealthController> _logger;

        public HealthController(ApplicationDbContext context, ILogger<HealthController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("database")]
        public async Task<IActionResult> CheckDatabase()
        {
            try
            {
                var canConnect = await _context.Database.CanConnectAsync();
                
                if (canConnect)
                {
                    var userCount = await _context.Usuarios.CountAsync();
                    var profileCount = await _context.Perfiles.CountAsync();
                    
                    return Ok(new
                    {
                        status = "Healthy",
                        database = "Connected",
                        timestamp = DateTime.Now,
                        statistics = new
                        {
                            usuarios = userCount,
                            perfiles = profileCount
                        },
                        message = "Conexión a la base de datos exitosa"
                    });
                }
                else
                {
                    return StatusCode(500, new
                    {
                        status = "Unhealthy",
                        database = "Disconnected",
                        timestamp = DateTime.Now,
                        message = "No se puede conectar a la base de datos"
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al verificar la base de datos");
                return StatusCode(500, new
                {
                    status = "Unhealthy",
                    database = "Error",
                    timestamp = DateTime.Now,
                    message = ex.Message,
                    detailed = ex.InnerException?.Message
                });
            }
        }

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok(new
            {
                status = "OK",
                message = "API is running",
                timestamp = DateTime.Now,
                environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development"
            });
        }
    }
}*/