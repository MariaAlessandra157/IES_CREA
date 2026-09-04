using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Entidades
{
     public class Pago
    {
        public int IdPago { get; set; }

        public int id_cuota { get; set; }

        public int id_personal { get; set; }

        public DateOnly fecha_pago { get; set; }

        public decimal monto { get; set; }

        public string medio_pago { get; set; }

        public string observacion { get; set; }
    }
}
