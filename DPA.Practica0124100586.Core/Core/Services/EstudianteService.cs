using DPA.Practica0124100586.Core.Core.DTOs;
using DPA.Practica0124100586.Core.Core.Entities;
using DPA.Practica0124100586.Core.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.Practica0124100586.Core.Core.Services
{
    public class EstudianteService : IEstudianteService
    {
        private readonly IEstudianteRepository _estudianteRepository;
        public EstudianteService(IEstudianteRepository estudianteRepository)
        {
            _estudianteRepository = estudianteRepository;
        }

        public async Task<IEnumerable<EstudianteListDTO>> GetEstudiantes()
        {
            var estudiantes = await _estudianteRepository.GetEstudiantes();
            var estudiantesDTO = new List<EstudianteListDTO>();
            foreach (var estudiante in estudiantes)
            {
                var estudianteDTO = new EstudianteListDTO();
                estudianteDTO.Id = estudiante.Id;
                estudianteDTO.Paterno = estudiante.Paterno;
                estudianteDTO.Materno = estudiante.Materno;
                estudianteDTO.Nombres = estudiante.Nombres;
                estudianteDTO.CarreraId = estudiante.CarreraId;
                estudiantesDTO.Add(estudianteDTO);
            }
            return estudiantesDTO;
        }

        public async Task<EstudianteListDTO> GetEstudianteById(int id)
        {
            var estudiante = await _estudianteRepository.GetEstudianteById(id);
            if (estudiante == null) return null;
            var estudianteDTO = new EstudianteListDTO();
            estudianteDTO.Id = estudiante.Id;
            estudianteDTO.Paterno = estudiante.Paterno;
            estudianteDTO.Materno = estudiante.Materno;
            estudianteDTO.Nombres = estudiante.Nombres;
            estudianteDTO.CarreraId = estudiante.CarreraId;
            return estudianteDTO;
        }

        public async Task<int> Crear(CreateEstudianteDTO createEstudianteDTO)
        {
            var estudiante = new Estudiante();
            estudiante.Paterno = createEstudianteDTO.Paterno;
            estudiante.Materno = createEstudianteDTO.Materno;
            estudiante.Nombres = createEstudianteDTO.Nombres;
            estudiante.FechaNacimiento = DateOnly.Parse(createEstudianteDTO.FechaNacimiento);
            estudiante.CarreraId = createEstudianteDTO.CarreraId;
            var createEstudianteId = await _estudianteRepository.Crear(estudiante);
            return createEstudianteId;
        }

        public async Task<int> Actualizar(int id, UpdateEstudianteDTO updateEstudianteDTO)
        {
            var estudiante = await _estudianteRepository.GetEstudianteById(id);
            if (estudiante == null) return 0;
            estudiante.Paterno = updateEstudianteDTO.Paterno;
            estudiante.Materno = updateEstudianteDTO.Materno;
            estudiante.Nombres = updateEstudianteDTO.Nombres;
            estudiante.Correo = updateEstudianteDTO.Correo;
            estudiante.FechaNacimiento = DateOnly.Parse(updateEstudianteDTO.FechaNacimiento);
            estudiante.CarreraId = updateEstudianteDTO.CarreraId;
            var updateEstudianteId = await _estudianteRepository.Actualizar(estudiante);
            return updateEstudianteId;
        }

        public async Task<int> Eliminar(int id)
        {
            var deleteEstudianteId = await _estudianteRepository.Eliminar(id);
            return deleteEstudianteId;
        }
    }
}
