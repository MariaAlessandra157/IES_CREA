using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IES_CREA.CORE.Entidades
{
    [Table("institucion-educativa")]
    public class Institucion
    {
        [Column("IdInstitucion")]
        [Key]
        public int IdInstitucion { get; set; }

        [Column("nombre")]
        [Required]
        [StringLength(100)]
        public string nombre { get; set; }

        [Column("direccion")]
        [Required]
        [StringLength(100)]
        public string direccion { get; set; }

        [Column("telefono")]
        [Required]
        [StringLength(20)]
        public string telefono { get; set; }

        [Column("email")]
        [Required]
        [StringLength(100)]
        public string email { get; set; }

        [Column("activo")]
        [Display(Name = "email")]
        public bool activo { get; set; }
    }
}
