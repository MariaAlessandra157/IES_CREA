using System;
using System.ComponentModel.DataAnnotations;

namespace IES_CREA.API.DTOs.Finanzas
{
    public class PagoActualizarDto
    {
        [Required]
        public int IdPago { get; set; }

        [Required(ErrorMessage = "El ID de la cuota es obligatorio.")]
        public int IdCuota { get; set; }

        [Required(ErrorMessage = "El ID del personal es obligatorio.")]
        public int IdPersonal { get; set; }

        [Required(ErrorMessage = "La fecha de pago es obligatoria.")]
        public DateOnly FechaPago { get; set; }

        [Required(ErrorMessage = "El monto es obligatorio.")]
        [Range(0.01, double.MaxValue)]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "El medio de pago es obligatorio.")]
        [StringLength(50)]
        public string MedioPago { get; set; } = string.Empty;

        [Required(ErrorMessage = "La observación es obligatoria.")]
        [StringLength(300)]
        public string Observacion { get; set; } = string.Empty;
    }
}