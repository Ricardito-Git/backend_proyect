/*Ricardo Rodrigo*/
using backend_proyect.Models.Entities;

namespace backend_proyect.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<Usuario>> GetAllUsuariosAsync();
        Task<Usuario> GetUsuarioByIdAsync(int id);
        Task<Usuario> CreateUsuarioAsync(Usuario usuario);
        Task<Usuario> UpdateUsuarioAsync(int id, Usuario usuario);
        Task<bool> DeleteUsuarioAsync(int id);
    }
}