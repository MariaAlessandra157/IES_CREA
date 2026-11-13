using System;
using System.ComponentModel.DataAnnotations;

namespace IES_CREA.API.DTOs.Academico
{
    public class TrayectoriaCrearDto
    {
        [Required(ErrorMessage = "El ID del alumno es obligatorio.")]
        [Range(1, int.MaxValue)]
        public int IdAlumno { get; set; }

        [Required(ErrorMessage = "El ID de la institución es obligatorio.")]
        [Range(1, int.MaxValue)]
        public int IdInstitucion { get; set; }

        [Required(ErrorMessage = "El ID del curso es obligatorio.")]
        [Range(1, int.MaxValue)]
        public int IdCurso { get; set; }

        [Required(ErrorMessage = "La división es obligatoria.")]
        [StringLength(20)]
        public string Division { get; set; } = string.Empty;

        [Required(ErrorMessage = "El ciclo lectivo es obligatorio.")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "El ciclo lectivo debe tener 4 caracteres (ej: 2026).")]
        public string Ciclolectivo { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha desde es obligatoria.")]
        public DateOnly FechaDesde { get; set; }

        [Required(ErrorMessage = "La fecha hasta es obligatoria.")]
        public DateOnly FechaHasta { get; set; }

        [Required(ErrorMessage = "Las observaciones son obligatorias.")]
        [StringLength(200)]
        public string Observaciones { get; set; } = string.Empty;
    }
}
