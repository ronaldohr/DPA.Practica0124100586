using DPA.Practica0124100586.Core.Core.Entities;

namespace DPA.Practica0124100586.Core.Core.Interfaces
{
    public interface IEstudianteRepository
    {
        Task<int> Actualizar(Estudiante estudiante);
        Task<int> Crear(Estudiante estudiante);
        Task<int> Eliminar(int id);
        Task<Estudiante> GetEstudianteById(int id);
        Task<IEnumerable<Estudiante>> GetEstudiantes();
    }
}