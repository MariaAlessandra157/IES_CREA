using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Entidades
{
    public class Cuota
    {
        public int IdCuotas { get; set; }

        public int id_arancel { get; set; }

        public int id_inscripcion { get; set; }

        public string periodo { get; set; }

        public decimal monto { get; set; }

        public DateOnly fecha_vencimiento { get; set; }

        public bool estado { get; set; }

    }
}
