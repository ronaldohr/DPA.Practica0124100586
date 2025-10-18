using DPA.Practica0124100586.Core.Core.Entities;
using DPA.Practica0124100586.Core.Core.Interfaces;
using DPA.Practica0124100586.Core.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.Practica0124100586.Core.Infraestructure.Repositories
{
    public class EstudianteRepository : IEstudianteRepository
    {
        private readonly DbuniversidadContext _context;

        public EstudianteRepository(DbuniversidadContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Estudiante>> GetEstudiantes()
        {
            // Trae los estudiantes existentes
            var estudiantes = await _context.Estudiante.ToListAsync();
            return estudiantes;
        }

        public async Task<Estudiante> GetEstudianteById(int id)
        {
            // Busca una estudiante por su ID
            var estudiantes = await _context.Estudiante.FindAsync(id);
            return estudiantes;
        }

        public async Task<int> Crear(Estudiante estudiante)
        {
            await _context.Estudiante.AddAsync(estudiante);
            // Guarda los cambios en la base de datos
            await _context.SaveChangesAsync();
            return estudiante.Id;
        }

        public async Task<int> Actualizar(Estudiante estudiante)
        {
            _context.Estudiante.Update(estudiante);
            await _context.SaveChangesAsync();
            return estudiante.Id;
        }

        public async Task<int> Eliminar(int id)
        {
            var estudiante = await _context.Estudiante.FindAsync(id);
            if (estudiante != null)
            {
                _context.Estudiante.Remove(estudiante);
                await _context.SaveChangesAsync();
                return estudiante.Id;
            }
            return 0; // O lanza una excepción si prefieres
        }

    }
}
