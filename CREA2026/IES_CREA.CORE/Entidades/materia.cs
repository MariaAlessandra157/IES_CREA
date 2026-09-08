using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Entidades
{
    public class materia
    {
        public int IdMateria { get; set; }

        public string nombre { get; set; }

        public string descripcion { get; set; }

        public bool activo { get; set; }
    }
}
