using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Entidades
{
    public class AlumnoResponsable
    {
        public int IdAlumnoResponsable { get; set}

        public int id_alumno {  get; set; }

        public int id_responsable { get; set; }

        public string parentesco { get; set; }

        public bool esContactoPrincipal { get; set; }


    }
}
