using System;
using System.ComponentModel.DataAnnotations;

namespace IES_CREA.API.DTOs.Persona
{
    public class AlumnoActualizarDto
    {
        [Required]
        public int IdAlumno { get; set; }

        [Required(ErrorMessage = "El ID de la persona es obligatorio.")]
        public int IdPersona { get; set; }

        [Required(ErrorMessage = "La fecha de ingreso es obligatoria.")]
        public DateOnly FechaIngreso { get; set; }

        [Required(ErrorMessage = "La fecha de egreso es obligatoria.")]
        public DateOnly FechaEgreso { get; set; }

        [Required(ErrorMessage = "La observación es obligatoria.")]
        [StringLength(300)]
        public string Observaciones { get; set; } = string.Empty;

        public bool Activo { get; set; } // <-- Agregado para activar/desactivar
    }
}