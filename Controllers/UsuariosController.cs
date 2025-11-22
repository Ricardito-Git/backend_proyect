//Cesar Gutiérrez

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend_proyect.Models;
using backend_proyect.Models.Entities;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public UsuariosController(ApplicationDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _context.Usuarios
            .Include(u => u.Perfil)
            .Where(u => u.Activo)
            .Select(u => new {
                u.IdUsuario,
                u.Nombre,
                Perfil = u.Perfil.Descripcion, // Cambiado de Nombre a Descripcion
                u.Activo,
                u.FechaUltMov
            })
            .ToListAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var u = await _context.Usuarios
            .Include(x => x.Perfil)
            .FirstOrDefaultAsync(x => x.IdUsuario == id);
        
        if (u == null || !u.Activo) return NotFound();
        
        return Ok(new {
            u.IdUsuario,
            u.Nombre,
            u.IdPerfil,
            Perfil = u.Perfil?.Descripcion, // Cambiado de Nombre a Descripcion
            u.Activo,
            u.FechaUltMov,
            u.UsuarioUltMov
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create(Usuario user)
    {
        // Validación básica
        if (string.IsNullOrEmpty(user.Nombre) || string.IsNullOrEmpty(user.Password))
            return BadRequest("Nombre y Password son requeridos");

        user.Activo = true;
        user.FechaUltMov = DateTime.Now;
        // TODO: Hash password antes de guardar
        // user.Password = HashPassword(user.Password);
        
        _context.Usuarios.Add(user);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(Get), new { id = user.IdUsuario }, new {
            user.IdUsuario,
            user.Nombre,
            user.IdPerfil,
            user.Activo,
            user.FechaUltMov
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Usuario user)
    {
        if (id != user.IdUsuario) return BadRequest("ID no coincide");

        var existingUser = await _context.Usuarios.FindAsync(id);
        if (existingUser == null || !existingUser.Activo) return NotFound();

        // Actualizar solo campos permitidos
        existingUser.Nombre = user.Nombre;
        existingUser.IdPerfil = user.IdPerfil;
        existingUser.Activo = user.Activo;
        existingUser.FechaUltMov = DateTime.Now;
        existingUser.UsuarioUltMov = user.UsuarioUltMov;

        // Solo actualizar password si se proporciona uno nuevo
        if (!string.IsNullOrEmpty(user.Password))
        {
            // TODO: Hash password antes de guardar
            // existingUser.Password = HashPassword(user.Password);
            existingUser.Password = user.Password;
        }

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UsuarioExists(id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var u = await _context.Usuarios.FindAsync(id);
        if (u == null) return NotFound();
        
        u.Activo = false;
        u.FechaUltMov = DateTime.Now;
        
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool UsuarioExists(int id)
    {
        return _context.Usuarios.Any(e => e.IdUsuario == id);
    }
}