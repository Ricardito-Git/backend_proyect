// Services/Interfaces/IAuthService.cs
/*Ricardo Rodrigo*/
using backend_proyect.Models.DTOs.auth;
using backend_proyect.Models.Entities;

namespace backend_proyect.Services.Interfaces
{
    public interface IAuthService
    {
        Task<UsuarioResponseDto> Login(LoginDto loginDto);
        Task<UsuarioResponseDto> Registro(RegistroDto registroDto);
        string GenerateJwtToken(Usuario usuario);
    }
}