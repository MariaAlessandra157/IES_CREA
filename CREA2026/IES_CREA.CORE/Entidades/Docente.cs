using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Entidades
{
    internal class Docente
    {
        public int IdDocente { get; set; }

        public int id_persona { get; set; }

        public string especialidad { get; set; }

        public DateOnly fecha_alta { get; set; }

        public bool activo { get; set; }


    }
}
