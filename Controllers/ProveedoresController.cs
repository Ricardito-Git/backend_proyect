using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend_proyect.Models;
using backend_proyect.Models.Entities;

[Route("api/[controller]")]
[ApiController]
public class ProveedoresController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public ProveedoresController(ApplicationDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _context.Proveedores.Where(p => p.Activo).ToListAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var p = await _context.Proveedores.FindAsync(id);
        if (p == null || !p.Activo) return NotFound();
        return Ok(p);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Proveedor proveedor)
    {
        proveedor.Activo = true;
        proveedor.FechaUltMov = DateTime.Now;
        _context.Proveedores.Add(proveedor);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = proveedor.IdProveedor }, proveedor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Proveedor proveedor)
    {
        if (id != proveedor.IdProveedor) return BadRequest();
        proveedor.FechaUltMov = DateTime.Now;
        _context.Entry(proveedor).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var p = await _context.Proveedores.FindAsync(id);
        if (p == null) return NotFound();
        p.Activo = false;
        p.FechaUltMov = DateTime.Now;
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
