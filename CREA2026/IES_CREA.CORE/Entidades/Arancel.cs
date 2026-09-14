using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IES_CREA.CORE.Entidades
{
    [Table ("aranceles")]
    public class Arancel
    {
        [Column("IdArancel")]
        [Key]
        public int IdArancel { get; set; }

        [Column("nombre")]
        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [Column("descripcion")]
        [Required]
        [StringLength(300)]
        public string descripcion { get; set; }

        [Column("monto")]
        [Required]
        public decimal monto { get; set; }

        [Column("fecha_vigencia_desde")]
        [Required]
        public DateOnly fecha_vigencia_desde { get; set; }

        [Column("fecha_vigencia_hasta")]
        [Required]
        public DateOnly fecha_vigencia_hasta { get; set; }

        [Column("activo")]
        [Display(Name = "activo")]
        public bool activo { get; set; }

    }
}
