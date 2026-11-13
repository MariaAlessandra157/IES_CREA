using System;
using System.ComponentModel.DataAnnotations;

namespace IES_CREA.API.DTOs.Finanzas
{
    public class ArancelCrearDto
    {
        [Required(ErrorMessage = "El nombre del arancel es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(300, ErrorMessage = "La descripción no puede superar los 300 caracteres.")]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El monto es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a 0.")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "La fecha de vigencia desde es obligatoria.")]
        public DateOnly FechaVigenciaDesde { get; set; }

        [Required(ErrorMessage = "La fecha de vigencia hasta es obligatoria.")]
        public DateOnly FechaVigenciaHasta { get; set; }
    }
}