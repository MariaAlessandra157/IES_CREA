using System;

namespace IES_CREA.API.DTOs.Academico
{
    public class ClaseDto
    {
        public int IdClase { get; set; }
        public int IdDocente { get; set; }
        public int IdMateria { get; set; }
        public int IdAula { get; set; }
        public string TipoClase { get; set; } = string.Empty;
        public DateOnly Fecha { get; set; }
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFinal { get; set; }
        public bool Estado { get; set; }
        public string Observacion { get; set; } = string.Empty;
    }
}