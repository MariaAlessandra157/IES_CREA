using System;

namespace IES_CREA.API.DTOs.Finanzas
{
    public class CuotaDto
    {
        public int IdCuotas { get; set; }
        public int IdArancel { get; set; }
        public int IdInscripcion { get; set; }
        public string Periodo { get; set; } = string.Empty;
        public decimal Monto { get; set; }
        public DateOnly FechaVencimiento { get; set; }
        public bool Estado { get; set; }
    }
}