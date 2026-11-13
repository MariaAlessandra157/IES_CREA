using System;
using System.ComponentModel.DataAnnotations;

namespace IES_CREA.API.DTOs.Finanzas
{
    public class CuotaCrearDto
    {
        [Required(ErrorMessage = "El ID del arancel es obligatorio.")]
        [Range(1, int.MaxValue)]
        public int IdArancel { get; set; }

        [Required(ErrorMessage = "El ID de la inscripción es obligatorio.")]
        [Range(1, int.MaxValue)]
        public int IdInscripcion { get; set; }

        [Required(ErrorMessage = "El período es obligatorio.")]
        [StringLength(50, ErrorMessage = "El período no puede superar los 50 caracteres.")]
        public string Periodo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El monto es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a 0.")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "La fecha de vencimiento es obligatoria.")]
        public DateOnly FechaVencimiento { get; set; }
    }
}