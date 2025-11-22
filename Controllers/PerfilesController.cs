using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend_proyect.Models;
using backend_proyect.Models.Entities;

[Route("api/[controller]")]
[ApiController]
public class PerfilesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PerfilesController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var perfiles = await _context.Perfiles
            .Where(p => p.Activo)
            .Select(p => new {
                p.IdPerfil, // Cambiado de "Id" a "IdPerfil"
                p.Descripcion,
                p.Activo,
                p.FechaUltMov // Cambiado de "FechaCreacion" a "FechaUltMov"
            })
            .ToListAsync();
        return Ok(perfiles);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var perfil = await _context.Perfiles
            .FirstOrDefaultAsync(p => p.IdPerfil == id && p.Activo); // Cambiado de "Id" a "IdPerfil"
        
        if (perfil == null) return NotFound();
        
        return Ok(new {
            perfil.IdPerfil, // Cambiado de "Id" a "IdPerfil"
            perfil.Descripcion,
            perfil.Activo,
            perfil.FechaUltMov // Cambiado de "FechaCreacion" a "FechaUltMov"
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create(Perfil perfil)
    {
        perfil.Activo = true;
        perfil.FechaUltMov = DateTime.Now; // Cambiado de "FechaCreacion" a "FechaUltMov"
        
        _context.Perfiles.Add(perfil);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(Get), new { id = perfil.IdPerfil }, perfil); // Cambiado de "Id" a "IdPerfil"
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Perfil perfil)
    {
        if (id != perfil.IdPerfil) return BadRequest(); // Cambiado de "Id" a "IdPerfil"
        
        perfil.FechaUltMov = DateTime.Now; // Cambiado de "FechaCreacion" a "FechaUltMov"
        _context.Entry(perfil).State = EntityState.Modified;
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PerfilExists(id))
                return NotFound();
            else
                throw;
        }
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var perfil = await _context.Perfiles.FindAsync(id);
        if (perfil == null) return NotFound();
        
        perfil.Activo = false;
        perfil.FechaUltMov = DateTime.Now; // Cambiado de "FechaCreacion" a "FechaUltMov"
        
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool PerfilExists(int id)
    {
        return _context.Perfiles.Any(e => e.IdPerfil == id); // Cambiado de "Id" a "IdPerfil"
    }
}