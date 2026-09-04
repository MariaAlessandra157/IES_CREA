using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Entidades
{
    public class DisponibilidadDocente
    {
        public int IdDisponibilidad { get; set; }

        public int id_docente { get; set; }

        public string dia_semana { get; set; }

        public TimeOnly hora_inicio { get; set; }

        public TimeOnly hora_final { get; set; }

        public string turno { get; set; }

        public bool activo { get; set; }
    }
}
