using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Entidades
{
    public class Personal
    {
        public int IdPersonal { get; set; }

        public int id_persona { get; set; }

        public int id_cargo { get; set; }

        public DateOnly fecha_ingreso { get; set; }

        public bool activo { get; set; }

    }
}
