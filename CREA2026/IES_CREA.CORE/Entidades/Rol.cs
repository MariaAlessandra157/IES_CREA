using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IES_CREA.CORE.Entidades
{
    [Table ("roles")]
    public class Rol
    {
        [Column("IdRol")]
        [Key]
        public int IdRol { get; set; }

        [Column("nombre")]
        [Required]
        [StringLength(50, ErrorMessage = "El nombre no debe superar los 50 caracteres.")]
        public string Nombre { get; set; }

        [Column("descripcion")]
        [Required]
        [StringLength(255, ErrorMessage = "La descripcion no debe superar los 255 caracteres.")]
        public string Descripcion { get; set; }
    }
}
