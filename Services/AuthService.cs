/*Ricardo Rodrigo*/
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using backend_proyect.Models;
using backend_proyect.Models.DTOs.auth;
using backend_proyect.Models.Entities;
using backend_proyect.Services.Interfaces;

namespace backend_proyect.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<UsuarioResponseDto> Login(LoginDto loginDto)
        {
            try
            {
                // Buscar usuario por nombre
                var usuario = await _context.Usuarios
                    .Include(u => u.Perfil)
                    .FirstOrDefaultAsync(u => u.Nombre == loginDto.Nombre && u.Activo);

                if (usuario == null)
                    throw new Exception("Usuario no encontrado");

                // Verificar password (en producción usar hash)
                if (usuario.Password != loginDto.Password)
                    throw new Exception("Contraseña incorrecta");

                // Generar token
                var token = GenerateJwtToken(usuario);

                return new UsuarioResponseDto
                {
                    IdUsuario = usuario.IdUsuario,
                    Nombre = usuario.Nombre,
                    Perfil = usuario.Perfil?.Descripcion,
                    Token = token
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en login: {ex.Message}");
            }
        }

        public async Task<UsuarioResponseDto> Registro(RegistroDto registroDto)
        {
            try
            {
                // Verificar si el usuario ya existe
                var usuarioExistente = await _context.Usuarios
                    .FirstOrDefaultAsync(u => u.Nombre == registroDto.Nombre);

                if (usuarioExistente != null)
                    throw new Exception("El nombre de usuario ya está en uso");

                // Verificar que el perfil exista
                var perfil = await _context.Perfiles
                    .FirstOrDefaultAsync(p => p.IdPerfil == registroDto.IdPerfil && p.Activo);

                if (perfil == null)
                    throw new Exception("El perfil especificado no existe");

                // Crear nuevo usuario - NO asignamos IdUsuario (es autoincrement)
                var nuevoUsuario = new Usuario
                {
                    // IdUsuario se genera automáticamente
                    Nombre = registroDto.Nombre,
                    Password = registroDto.Password, // En producción, hashear la contraseña
                    IdPerfil = registroDto.IdPerfil,
                    Activo = true,
                    FechaUltMov = DateTime.Now,
                    UsuarioUltMov = 1 // Usamos 1 como valor por defecto para el usuario que crea
                };

                _context.Usuarios.Add(nuevoUsuario);
                await _context.SaveChangesAsync();

                // Recargar el usuario con los datos del perfil
                var usuarioCreado = await _context.Usuarios
                    .Include(u => u.Perfil)
                    .FirstOrDefaultAsync(u => u.IdUsuario == nuevoUsuario.IdUsuario);

                if (usuarioCreado == null)
                    throw new Exception("Error al crear el usuario");

                // Generar token
                var token = GenerateJwtToken(usuarioCreado);

                return new UsuarioResponseDto
                {
                    IdUsuario = usuarioCreado.IdUsuario,
                    Nombre = usuarioCreado.Nombre,
                    Perfil = usuarioCreado.Perfil?.Descripcion,
                    Token = token
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en registro: {ex.Message}");
            }
        }

        public string GenerateJwtToken(Usuario usuario)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = Encoding.ASCII.GetBytes(jwtSettings["SecretKey"]);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nombre),
                new Claim(ClaimTypes.Role, usuario.Perfil?.Descripcion ?? "Usuario"),
                new Claim("PerfilId", usuario.IdPerfil.ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(Convert.ToDouble(jwtSettings["ExpirationHours"] ?? "2")),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), 
                    SecurityAlgorithms.HmacSha256Signature
                ),
                Issuer = jwtSettings["Issuer"],
                Audience = jwtSettings["Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}