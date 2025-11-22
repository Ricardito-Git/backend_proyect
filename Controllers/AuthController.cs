using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using backend_proyect.Models.DTOs.auth;
using backend_proyect.Services.Interfaces;

namespace backend_proyect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                _logger.LogInformation("Intento de login para usuario: {Usuario}", loginDto.Nombre);
                
                var result = await _authService.Login(loginDto);
                
                _logger.LogInformation("Login exitoso para usuario: {Usuario}", loginDto.Nombre);
                return Ok(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Login fallido para usuario {Usuario}: {Error}", loginDto.Nombre, ex.Message);
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpPost("registro")]
        public async Task<IActionResult> Registro([FromBody] RegistroDto registroDto)
        {
            try
            {
                _logger.LogInformation("Registro de nuevo usuario: {Usuario}", registroDto.Nombre);
                
                var result = await _authService.Registro(registroDto);
                
                _logger.LogInformation("Registro exitoso para usuario: {Usuario} con ID: {Id}", 
                    registroDto.Nombre, result.IdUsuario);
                return Ok(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Registro fallido para usuario {Usuario}: {Error}", registroDto.Nombre, ex.Message);
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpGet("status")]
        public IActionResult Status()
        {
            return Ok(new 
            { 
                message = "Servicio de autenticación funcionando",
                timestamp = DateTime.Now,
                environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development"
            });
        }
    }
}