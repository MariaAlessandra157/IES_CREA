using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace IES_CREA.CORE.Entidades
{
    public class Asistencia
    {
        public int IdAsistencia { get; set; }
        public int id_clase { get; set; }
        
        public int id_alumno { get; set; }

        public bool estado { get; set; }

        public string observacion { get; set; }
    }
}
