using System;
using System.ComponentModel.DataAnnotations;

namespace IES_CREA.API.DTOs.Academico
{
    public class SeguimientoActualizarDto
    {
        [Required]
        public int IdSeguimiento { get; set; }

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