using System;
using System.ComponentModel.DataAnnotations;

namespace IES_CREA.API.DTOs.Academico
{
    public class InscripcionCrearDto
    {
        [Required(ErrorMessage = "El ID del alumno es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID del alumno debe ser mayor a 0.")]
        public int IdAlumno { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es obligatoria.")]
        public DateOnly FechaInicio { get; set; }

        [Required(ErrorMessage = "La fecha de fin es obligatoria.")]
        public DateOnly FechaFin { get; set; }

        [Required(ErrorMessage = "El tipo de inscripción es obligatorio.")]
        [StringLength(50, ErrorMessage = "El tipo de inscripción no puede superar los 50 caracteres.")]
        public string TipoInscripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "La observación es obligatoria.")]
        [StringLength(500, ErrorMessage = "La observación no puede superar los 500 caracteres.")]
        public string Observacion { get; set; } = string.Empty;
    }
}