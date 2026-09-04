using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public int id_persona { get; set; }
        public string usuario { get; set; }
        public string password_hash { get; set; }
        public bool activo { get; set; }
        public DateOnly fecha_creacion { get; set; }
        public DateOnly ultimo_acceso { get; set; }
    }
}
