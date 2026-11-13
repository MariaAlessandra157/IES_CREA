using System;

namespace IES_CREA.API.DTOs.Finanzas
{
    public class ArancelDto
    {
        public int IdArancel { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Monto { get; set; }
        public DateOnly FechaVigenciaDesde { get; set; }
        public DateOnly FechaVigenciaHasta { get; set; }
        public bool Activo { get; set; }
    }
}