using System;

namespace IES_CREA.API.DTOs.Academico
{
    public class InscripcionDto
    {
        public int IdInscripcion { get; set; }
        public int IdAlumno { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFin { get; set; }
        public string TipoInscripcion { get; set; } = string.Empty;
        public bool Estado { get; set; }
        public string Observacion { get; set; } = string.Empty;
    }
}