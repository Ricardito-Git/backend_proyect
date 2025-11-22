using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend_proyect.Models;
using backend_proyect.Models.Entities;

[Route("api/[controller]")]
[ApiController]
public class AlmacenesController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public AlmacenesController(ApplicationDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _context.Almacenes.Where(a => a.Activo).ToListAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var a = await _context.Almacenes.FindAsync(id);
        if (a == null || !a.Activo) return NotFound();
        return Ok(a);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Almacen almacen)
    {
        almacen.Activo = true;
        almacen.FechaUltMov = DateTime.Now;
        _context.Almacenes.Add(almacen);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = almacen.IdAlmacen }, almacen);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Almacen almacen)
    {
        if (id != almacen.IdAlmacen) return BadRequest();
        almacen.FechaUltMov = DateTime.Now;
        _context.Entry(almacen).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var a = await _context.Almacenes.FindAsync(id);
        if (a == null) return NotFound();
        a.Activo = false;
        a.FechaUltMov = DateTime.Now;
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
