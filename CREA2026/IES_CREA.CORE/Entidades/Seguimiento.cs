using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Entidades
{
    public class Seguimiento
    {
        public int IdSeguimiento { get; set; }

        public int id_materia { get; set; }

        public int id_alumno { get; set; }

        public int id_docente { get; set; }

        public DateOnly fecha { get; set; }

        public string tema_trabajo { get; set; }

        public string avance { get; set; }

        public string dificultades { get; set; }

        public string recomendaciones { get; set; }

        public string observaciones { get; set; }
    }
}
