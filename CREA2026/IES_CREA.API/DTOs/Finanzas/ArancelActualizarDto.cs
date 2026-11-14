using System;
using System.ComponentModel.DataAnnotations;

namespace IES_CREA.API.DTOs.Finanzas
{
    public class ArancelActualizarDto
    {
        [Required]
        public int IdArancel { get; set; }

        [Required(ErrorMessage = "El nombre del arancel es obligatorio.")]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(300)]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El monto es obligatorio.")]
        [Range(0.01, double.MaxValue)]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "La fecha de vigencia desde es obligatoria.")]
        public DateOnly FechaVigenciaDesde { get; set; }

        [Required(ErrorMessage = "La fecha de vigencia hasta es obligatoria.")]
        public DateOnly FechaVigenciaHasta { get; set; }

        public bool Activo { get; set; } // <-- Agregado para activar/desactivar
    }
}