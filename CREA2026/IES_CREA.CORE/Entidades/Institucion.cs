using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Entidades
{
    public class Institucion
    {
        public int IdInstitucion { get; set; }

        public string nombre { get; set; }

        public string direccion { get; set; }

        public string telefono { get; set; }

        public string email { get; set; }

        public bool activo { get; set; }
    }
}
