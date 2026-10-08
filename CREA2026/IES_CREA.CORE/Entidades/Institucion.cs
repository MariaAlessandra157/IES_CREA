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
        public string Nombre { get; set; }

        [Column("direccion")]
        [Required]
        [StringLength(100)]
        public string Direccion { get; set; }

        [Column("telefono")]
        [Required]
        [StringLength(20)]
        [RegularExpression(@"^[1-9]\d{1,3}[1-9]\d{5,7}$", ErrorMessage = "Teléfono inválido. Use código de área sin 0 y número sin 15.")]
        public string Telefono { get; set; }

        [Column("email")]
        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Column("activo")]
        [Display(Name = "activo")]
        public bool Activo { get; set; }
    }
}
