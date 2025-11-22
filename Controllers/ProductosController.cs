using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend_proyect.Models;
using backend_proyect.Models.Entities;

[Route("api/[controller]")]
[ApiController]
public class ProductosController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public ProductosController(ApplicationDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _context.Productos.Where(p => p.Activo).ToListAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var p = await _context.Productos.FindAsync(id);
        if (p == null || !p.Activo) return NotFound();
        return Ok(p);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Producto prod)
    {
        prod.Activo = true;
        prod.FechaUltMov = DateTime.Now;
        _context.Productos.Add(prod);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = prod.IdProducto }, prod);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Producto prod)
    {
        if (id != prod.IdProducto) return BadRequest();
        prod.FechaUltMov = DateTime.Now;
        _context.Entry(prod).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var p = await _context.Productos.FindAsync(id);
        if (p == null) return NotFound();
        p.Activo = false;
        p.FechaUltMov = DateTime.Now;
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
