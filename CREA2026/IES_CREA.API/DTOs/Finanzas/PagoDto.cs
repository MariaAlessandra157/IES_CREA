using System;

namespace IES_CREA.API.DTOs.Finanzas
{
    public class PagoDto
    {
        public int IdPago { get; set; }
        public int IdCuota { get; set; }
        public int IdPersonal { get; set; }
        public DateOnly FechaPago { get; set; }
        public decimal Monto { get; set; }
        public string MedioPago { get; set; } = string.Empty;
        public string Observacion { get; set; } = string.Empty;
    }
}