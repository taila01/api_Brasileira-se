using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_brasileira_se.Data;
using api_brasileira_se.Models;

namespace api_brasileira_se.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PontoTuristicoController : ControllerBase
{
    private readonly AppDbContext _context;

    public PontoTuristicoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string? busca)
    {
        var query = _context.PontosTuristicos.AsQueryable();

        if (!string.IsNullOrEmpty(busca))
        {
            query = query.Where(p => p.Nome.Contains(busca) 
                                  || p.Descricao.Contains(busca) 
                                  || p.Localizacao.Contains(busca));
        }

        var lista = await query
            .OrderByDescending(p => p.DataInclusao)
            .ToListAsync();

        return Ok(lista);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var ponto = await _context.PontosTuristicos.FindAsync(id);

        if (ponto == null) return NotFound(new { message = "Ponto não encontrado" });

        return Ok(ponto);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PontoTuristico novoPonto)
    {
        novoPonto.DataInclusao = DateTime.Now;

        _context.PontosTuristicos.Add(novoPonto);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = novoPonto.Id }, novoPonto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] PontoTuristico pontoEditado)
    {
        if (id != pontoEditado.Id) return BadRequest("O ID do corpo não bate com o da URL");

        _context.Entry(pontoEditado).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.PontosTuristicos.Any(e => e.Id == id)) return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ponto = await _context.PontosTuristicos.FindAsync(id);
        if (ponto == null) return NotFound();

        _context.PontosTuristicos.Remove(ponto);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}