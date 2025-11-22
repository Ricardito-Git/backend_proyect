using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend_proyect.Models;
using backend_proyect.Models.Entities;

[Route("api/[controller]")]
[ApiController]
public class PasillosController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PasillosController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _context.Pasillos.Where(x => x.Activo).ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var item = await _context.Pasillos.FindAsync(id);
        if (item == null || !item.Activo) return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Pasillo e)
    {
        e.Activo = true;
        e.FechaUltMov = DateTime.Now;
        _context.Pasillos.Add(e);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = e.IdPasillo }, e);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Pasillo e)
    {
        if (id != e.IdPasillo) return BadRequest();
        e.FechaUltMov = DateTime.Now;
        _context.Entry(e).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _context.Pasillos.FindAsync(id);
        if (item == null) return NotFound();
        item.Activo = false;
        item.FechaUltMov = DateTime.Now;
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
