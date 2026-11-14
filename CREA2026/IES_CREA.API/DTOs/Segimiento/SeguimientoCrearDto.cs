using System;
using System.ComponentModel.DataAnnotations;

namespace IES_CREA.API.DTOs.Academico
{
    public class SeguimientoCrearDto
    {
        [Required(ErrorMessage = "El ID de la materia es obligatorio.")]
        [Range(1, int.MaxValue)]
        public int IdMateria { get; set; }

        [Required(ErrorMessage = "El ID del alumno es obligatorio.")]
        [Range(1, int.MaxValue)]
        public int IdAlumno { get; set; }

        [Required(ErrorMessage = "El ID del docente es obligatorio.")]
        [Range(1, int.MaxValue)]
        public int IdDocente { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateOnly Fecha { get; set; }

        [Required(ErrorMessage = "El tema trabajado es obligatorio.")]
        [StringLength(300)]
        public string TemaTrabajado { get; set; } = string.Empty;

        [Required(ErrorMessage = "El avance es obligatorio.")]
        [StringLength(300)]
        public string Avance { get; set; } = string.Empty;

        [Required(ErrorMessage = "Las dificultades son obligatorias.")]
        [StringLength(300)]
        public string Dificultades { get; set; } = string.Empty;

        [Required(ErrorMessage = "Las recomendaciones son obligatorias.")]
        [StringLength(300)]
        public string Recomendaciones { get; set; } = string.Empty;

        [Required(ErrorMessage = "Las observaciones son obligatorias.")]
        [StringLength(300)]
        public string Observaciones { get; set; } = string.Empty;
    }
}