using DPA.Practica0124100586.Core.Core.DTOs;
using DPA.Practica0124100586.Core.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DPA.Practica0124100586.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudianteService _estudianteService;

        public EstudianteController(IEstudianteService estudianteService)
        {
            _estudianteService = estudianteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEstudiantes()
        {
            var estudiante = await _estudianteService.GetEstudiantes();
            return Ok(estudiante);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEstudianteById(int id)
        {
            var estudiante = await _estudianteService.GetEstudianteById(id);
            if (estudiante == null)
            {
                return NotFound();
            }
            return Ok(estudiante);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CreateEstudianteDTO estudiante)
        {
            if (estudiante == null)
            {
                return BadRequest();
            }
            var estudianteId = await _estudianteService.Crear(estudiante);
            return CreatedAtAction(nameof(GetEstudianteById), new { id = estudianteId }, estudiante);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] UpdateEstudianteDTO estudiante)
        {
            if (estudiante == null)
            {
                return BadRequest();
            }
            var estudianteId = await _estudianteService.Actualizar(id, estudiante);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _estudianteService.Eliminar(id);
            if (result == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
