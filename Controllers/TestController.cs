using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend_proyect.Models;

namespace backend_proyect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TestController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("database")]
        public async Task<IActionResult> TestDatabase()
        {
            try
            {
                // Probar conexión a MySQL
                var canConnect = await _context.Database.CanConnectAsync();
                
                if (canConnect)
                {
                    var userCount = await _context.Usuarios.CountAsync();
                    var profileCount = await _context.Perfiles.CountAsync();
                    
                    return Ok(new {
                        Status = " MySQL Aiven conectada correctamente",
                        Users = userCount,
                        Profiles = profileCount,
                        Database = "MySQL Aiven Cloud",
                        Message = "¡La base de datos está funcionando!"
                    });
                }
                else
                {
                    return BadRequest(new {
                        Status = " No se pudo conectar a MySQL",
                        Message = "Revisa la cadena de conexión"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new {
                    Status = " Error de conexión MySQL",
                    Error = ex.Message,
                    Database = "Aiven Cloud"
                });
            }
        }

        [HttpGet("version")]
        public IActionResult GetVersion()
        {
            return Ok(new {
                Application = "Backend Proyect WMS",
                Version = "1.0.0",
                Database = "MySQL Aiven Cloud",
                Status = "Running",
                Timestamp = DateTime.Now
            });
        }
    }
}