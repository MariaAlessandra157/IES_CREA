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
        public int IdArancel { get; set; }

        [Column("id_inscripcion")]
        [Required]
        public int IdInscripcion { get; set; }

        [Column("periodo")]
        [Required]
        [StringLength(50)]
        public string Periodo { get; set; }

        [Column("monto")]
        [Required]
        public decimal Monto { get; set; }

        [Column("fecha_vencimiento")]
        [Required]
        public DateOnly FechaVencimiento { get; set; }

        [Column("estado")]
        [Display(Name = "estado")]
        public bool Estado { get; set; }

    }
}
