using System;

namespace IES_CREA.API.DTOs.Persona
{
    public class AlumnoDto
    {
        public int IdAlumno { get; set; }
        public int IdPersona { get; set; }
        public DateOnly FechaIngreso { get; set; }
        public DateOnly FechaEgreso { get; set; }
        public bool Activo { get; set; }
        public string Observaciones { get; set; } = string.Empty;
    }
}