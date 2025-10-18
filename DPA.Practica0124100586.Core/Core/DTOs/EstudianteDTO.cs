using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.Practica0124100586.Core.Core.DTOs
{
    public class EstudianteDTO
    {
        public int Id { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Nombres { get; set; }
        public int CarreraId { get; set; }
    }

    public class EstudianteListDTO
    {
        public int Id { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Nombres { get; set; }
        public int CarreraId { get; set; }
    }

    public class CreateEstudianteDTO
    {
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Nombres { get; set; }
        public string FechaNacimiento { get; set; }
        public int CarreraId { get; set; }
    }

    public class UpdateEstudianteDTO
    {
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Nombres { get; set; }
        public string? Correo { get; set; }
        public string FechaNacimiento { get; set; }
        public int CarreraId { get; set; }
    }

    public class DeleteEstudianteDTO
    {
        public int Id { get; set; }
    }

}
