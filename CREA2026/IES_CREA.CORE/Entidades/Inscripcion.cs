using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Entidades
{
    public class Inscripcion
    {
        public int IdInscripcion { get; set; }

        public int id_alumno { get; set; }
        
        public DateOnly fecha_inicio { get; set; }

        public DateOnly fecha_fin { get; set; }

        public string tipo_inscripcion { get; set; }

        public bool estado { get; set; }

        public string observacion { get; set; }

    }
}
