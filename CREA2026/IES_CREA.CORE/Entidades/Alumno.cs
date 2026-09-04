using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Entidades
{
    public class Alumno
    {
        public int IdAlumno { get; set; }

        public int id_persona { get; set; }

        public DateOnly fecha_ingreso { get; set; }

        public DateOnly fecha_egreso { get; set; }

        public bool activo { get; set; }

        public string observaciones { get; set; }

    }
}
