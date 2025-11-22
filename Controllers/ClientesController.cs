using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend_proyect.Models;
using backend_proyect.Models.Entities;

[Route("api/[controller]")]
[ApiController]
public class ClientesController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public ClientesController(ApplicationDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _context.Clientes.Where(c => c.Activo).ToListAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var c = await _context.Clientes.FindAsync(id);
        if (c == null || !c.Activo) return NotFound();
        return Ok(c);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Cliente cliente)
    {
        cliente.Activo = true;
        cliente.FechaUltMov = DateTime.Now;
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = cliente.IdCliente }, cliente);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Cliente cliente)
    {
        if (id != cliente.IdCliente) return BadRequest();
        cliente.FechaUltMov = DateTime.Now;
        _context.Entry(cliente).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var c = await _context.Clientes.FindAsync(id);
        if (c == null) return NotFound();
        c.Activo = false;
        c.FechaUltMov = DateTime.Now;
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
