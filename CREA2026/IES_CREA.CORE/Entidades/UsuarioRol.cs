using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IES_CREA.CORE.Entidades
{
    public class UsuarioRol
    {
        [Key]
        [Required(ErrorMessage = "El rol es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "El rol debe ser un valor positivo")]
        public int IdRol { get; set; }

        [Required(ErrorMessage = "El usuario es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "El usuario debe ser un valor positivo")]
        public int IdUsuario { get; set; }
    }
}
