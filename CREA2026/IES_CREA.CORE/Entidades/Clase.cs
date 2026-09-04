using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Entidades
{
    public class Clase
    {
        public int IdClase { get; set; }
        
        public int id_docente { get; set; }

        public int id_materia { get; set; }

        public int id_aula { get; set; }

        public string tipo_clase { get; set; }

        public DateOnly fecha { get; set; }

        public TimeOnly hora_inicio { get; set; }

        public TimeOnly hora_final { get; set; }

        public bool estado { get; set; }

        public string observacion { get; set; }

        public bool activo { get; set; }

    }
}
