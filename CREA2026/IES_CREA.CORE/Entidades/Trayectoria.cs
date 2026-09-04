using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Entidades
{
    public class Trayectoria
    {
        public int IdTrayectoria { get; set; }

        public int id_alumno { get; set; }

        public int id_curso { get; set; }

        public string division { get; set; }

        public string ciclo_lectivo { get; set; }

        public DateOnly fecha_desde { get; set; }

        public DateOnly fecha_hasta { get; set; }

        public string observaciones { get; set; }
    }
}
