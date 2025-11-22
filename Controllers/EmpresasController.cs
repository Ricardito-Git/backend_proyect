using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend_proyect.Models;
using backend_proyect.Models.Entities;

[Route("api/[controller]")]
[ApiController]
public class EmpresasController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public EmpresasController(ApplicationDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _context.Empresas.Where(e => e.Activo).ToListAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var e = await _context.Empresas.FindAsync(id);
        if (e == null || !e.Activo) return NotFound();
        return Ok(e);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Empresa empresa)
    {
        empresa.Activo = true;
        empresa.FechaUltMov = DateTime.Now;
        _context.Empresas.Add(empresa);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = empresa.IdEmpresa }, empresa);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Empresa empresa)
    {
        if (id != empresa.IdEmpresa) return BadRequest();
        empresa.FechaUltMov = DateTime.Now;
        _context.Entry(empresa).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var e = await _context.Empresas.FindAsync(id);
        if (e == null) return NotFound();
        e.Activo = false;
        e.FechaUltMov = DateTime.Now;
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
