using System;

namespace IES_CREA.API.DTOs.Academico
{
    public class SeguimientoDto
    {
        public int IdSeguimiento { get; set; }
        public int IdMateria { get; set; }
        public int IdAlumno { get; set; }
        public int IdDocente { get; set; }
        public DateOnly Fecha { get; set; }
        public string TemaTrabajado { get; set; } = string.Empty;
        public string Avance { get; set; } = string.Empty;
        public string Dificultades { get; set; } = string.Empty;
        public string Recomendaciones { get; set; } = string.Empty;
        public string Observaciones { get; set; } = string.Empty;
    }
}
