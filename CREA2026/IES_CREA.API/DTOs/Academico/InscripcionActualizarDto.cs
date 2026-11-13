using System;
using System.ComponentModel.DataAnnotations;

namespace IES_CREA.API.DTOs.Academico
{
    public class InscripcionActualizarDto
    {
        [Required]
        public int IdInscripcion { get; set; }

        [Required(ErrorMessage = "El ID del alumno es obligatorio.")]
        [Range(1, int.MaxValue)]
        public int IdAlumno { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es obligatoria.")]
        public DateOnly FechaInicio { get; set; }

        [Required(ErrorMessage = "La fecha de fin es obligatoria.")]
        public DateOnly FechaFin { get; set; }

        [Required(ErrorMessage = "El tipo de inscripción es obligatorio.")]
        [StringLength(50)]
        public string TipoInscripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "La observación es obligatoria.")]
        [StringLength(500)]
        public string Observacion { get; set; } = string.Empty;

        public bool Estado { get; set; } // <-- Agregado para que puedas activar/desactivar
    }
}