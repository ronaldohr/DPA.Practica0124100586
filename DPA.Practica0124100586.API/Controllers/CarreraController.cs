using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DPA.Practica0124100586.Core.Core.Entities;
using DPA.Practica0124100586.Core.Infraestructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DPA.Practica0124100586.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarreraController : ControllerBase
{
    private readonly DbuniversidadContext _context;

    public CarreraController(DbuniversidadContext context)
    {
        _context = context;
    }

    // GET: api/Carrera
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Carrera>>> GetCarrera()
    {
        return await _context.Carrera.ToListAsync();
    }

    // GET: api/Carrera/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Carrera>> GetCarrera(int id)
    {
        var carrera = await _context.Carrera.FindAsync(id);

        if (carrera == null)
        {
            return NotFound();
        }

        return carrera;
    }

    // POST: api/Carrera
    [HttpPost]
    public async Task<ActionResult<Carrera>> PostCarrera(Carrera carrera)
    {
        _context.Carrera.Add(carrera);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCarrera), new { id = carrera.Id }, carrera);
    }

    // PUT: api/Carrera/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCarrera(int id, Carrera carrera)
    {
        if (id != carrera.Id)
        {
            return BadRequest();
        }

        _context.Entry(carrera).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CarreraExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/Carrera/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCarrera(int id)
    {
        var carrera = await _context.Carrera.FindAsync(id);
        if (carrera == null)
        {
            return NotFound();
        }

        _context.Carrera.Remove(carrera);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CarreraExists(int id)
    {
        return _context.Carrera.Any(e => e.Id == id);
    }
}
