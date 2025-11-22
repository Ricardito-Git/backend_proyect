/*Ricardo Rodrigo*/
using backend_proyect.Models;
using backend_proyect.Models.Entities;
using backend_proyect.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend_proyect.Services
{
    public class UsuarioService : IUsuarioService  // Implementa la interfaz
    {
        private readonly ApplicationDbContext _context;

        public UsuarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> GetAllUsuariosAsync()
        {
            return await _context.Usuarios
                .Include(u => u.Perfil)
                .Where(u => u.Activo)
                .ToListAsync();
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            return await _context.Usuarios
                .Include(u => u.Perfil)
                .FirstOrDefaultAsync(u => u.IdUsuario == id && u.Activo);
        }

        public async Task<Usuario> CreateUsuarioAsync(Usuario usuario)
        {
            var perfilExists = await _context.Perfiles
                .AnyAsync(p => p.IdPerfil == usuario.IdPerfil);
            
            if (!perfilExists)
                throw new Exception("El perfil seleccionado no existe");

            usuario.Activo = true;
            usuario.FechaUltMov = DateTime.Now;
            
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            
            return usuario;
        }

        public async Task<Usuario> UpdateUsuarioAsync(int id, Usuario usuario)
        {
            if (id != usuario.IdUsuario)
                throw new Exception("ID no coincide");

            var existingUsuario = await _context.Usuarios.FindAsync(id);
            if (existingUsuario == null)
                throw new Exception("Usuario no encontrado");

            var perfilExists = await _context.Perfiles
                .AnyAsync(p => p.IdPerfil == usuario.IdPerfil);
            
            if (!perfilExists)
                throw new Exception("El perfil seleccionado no existe");

            existingUsuario.Nombre = usuario.Nombre;
            existingUsuario.IdPerfil = usuario.IdPerfil;
            existingUsuario.Activo = usuario.Activo;
            existingUsuario.FechaUltMov = DateTime.Now;
            existingUsuario.UsuarioUltMov = usuario.UsuarioUltMov;

            if (!string.IsNullOrEmpty(usuario.Password))
            {
                existingUsuario.Password = BCrypt.Net.BCrypt.HashPassword(usuario.Password);
            }
            

            await _context.SaveChangesAsync();
            return existingUsuario;
        }

        public async Task<bool> DeleteUsuarioAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                return false;

            usuario.Activo = false;
            usuario.FechaUltMov = DateTime.Now;
            
            await _context.SaveChangesAsync();
            return true;
        }
    }
}