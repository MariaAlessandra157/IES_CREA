using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Entidades
{
    public class InscripcionMateria
    {
        public int IdInscripcionMateria { get; set; }

        public int id_inscripcion { get; set; }

        public int id_materia { get; set; }

        public DateOnly fecha_inicio { get; set; }

        public DateOnly fecha_fin { get; set; }

        public bool estado { get; set; }

    }
}
