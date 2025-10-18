using DPA.Practica0124100586.Core.Core.DTOs;

namespace DPA.Practica0124100586.Core.Core.Interfaces
{
    public interface IEstudianteService
    {
        Task<int> Actualizar(int id, UpdateEstudianteDTO updateEstudianteDTO);
        Task<int> Crear(CreateEstudianteDTO createEstudianteDTO);
        Task<int> Eliminar(int id);
        Task<EstudianteListDTO> GetEstudianteById(int id);
        Task<IEnumerable<EstudianteListDTO>> GetEstudiantes();
    }
}