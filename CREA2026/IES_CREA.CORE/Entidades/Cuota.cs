using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IES_CREA.CORE.Entidades
{
    [Table ("cuotas")]
    public class Cuota
    {
        [Column("IdCuotas")]
        [Key]
        public int IdCuotas { get; set; }

        [Column("id_arancel")]
        [Required]
        public int id_arancel { get; set; }

        [Column("id_inscripcion")]
        [Required]
        public int id_inscripcion { get; set; }

        [Column("periodo")]
        [Required]
        [StringLength(50)]
        public string periodo { get; set; }

        [Column("monto")]
        [Required]
        public decimal monto { get; set; }

        [Column("fecha_vencimiento")]
        [Required]
        public DateOnly fecha_vencimiento { get; set; }

        [Column("estado")]
        [Display(Name = "estado")]
        public bool estado { get; set; }

    }
}
