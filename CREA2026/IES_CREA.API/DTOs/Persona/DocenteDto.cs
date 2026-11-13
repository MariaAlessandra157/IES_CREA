using System;

namespace IES_CREA.API.DTOs.Persona
{
    public class DocenteDto
    {
        public int IdDocente { get; set; }
        public int IdPersona { get; set; }
        public string Especialidad { get; set; } = string.Empty;
        public DateOnly FechaAlta { get; set; }
        public bool Activo { get; set; }
    }
}