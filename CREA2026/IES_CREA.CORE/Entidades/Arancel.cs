using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Entidades
{
    public class Arancel
    {
        public int IdArancel { get; set; }

        public string nombre { get; set; }

        public string descripcion { get; set; }

        public decimal monto { get; set; }

        public DateOnly fecha_vigencia_desde { get; set; }

        public DateOnly fecha_vigencia_hasta { get; set; }

        public bool activo { get; set; }

    }
}
