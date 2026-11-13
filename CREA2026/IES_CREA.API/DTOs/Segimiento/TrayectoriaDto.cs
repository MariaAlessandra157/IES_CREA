using System;

namespace IES_CREA.API.DTOs.Academico
{
    public class TrayectoriaDto
    {
        public int IdTrayectoria { get; set; }
        public int IdAlumno { get; set; }
        public int IdInstitucion { get; set; }
        public int IdCurso { get; set; }
        public string Division { get; set; } = string.Empty;
        public string Ciclolectivo { get; set; } = string.Empty;
        public DateOnly FechaDesde { get; set; }
        public DateOnly FechaHasta { get; set; }
        public string Observaciones { get; set; } = string.Empty;
    }
}
