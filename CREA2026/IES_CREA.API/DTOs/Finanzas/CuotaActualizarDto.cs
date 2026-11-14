using System;
using System.ComponentModel.DataAnnotations;

namespace IES_CREA.API.DTOs.Finanzas
{
    public class CuotaActualizarDto
    {
        [Required]
        public int IdCuotas { get; set; }

        [Required(ErrorMessage = "El monto es obligatorio.")]
        [Range(0.01, double.MaxValue)]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "La fecha de vencimiento es obligatoria.")]
        public DateOnly FechaVencimiento { get; set; }

        public bool Estado { get; set; } // <-- Agregado para marcar como pagada/pendiente
    }
}