using System;
using System.ComponentModel.DataAnnotations;

namespace IES_CREA.API.DTOs.Academico
{
    public class ClaseActualizarDto
    {
        [Required]
        public int IdClase { get; set; }

        [Required(ErrorMessage = "El ID del docente es obligatorio.")]
        public int IdDocente { get; set; }

        [Required(ErrorMessage = "El ID de la materia es obligatorio.")]
        public int IdMateria { get; set; }

        [Required(ErrorMessage = "El ID del aula es obligatorio.")]
        public int IdAula { get; set; }

        [Required(ErrorMessage = "El tipo de clase es obligatorio.")]
        [StringLength(50)]
        public string TipoClase { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateOnly Fecha { get; set; }

        [Required(ErrorMessage = "La hora de inicio es obligatoria.")]
        public TimeOnly HoraInicio { get; set; }

        [Required(ErrorMessage = "La hora de fin es obligatoria.")]
        public TimeOnly HoraFinal { get; set; }

        [Required(ErrorMessage = "La observación es obligatoria.")]
        [StringLength(300)]
        public string Observacion { get; set; } = string.Empty;

        public bool Estado { get; set; } // <-- Agregado para activar/desactivar
    }
}