using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IES_CREA.CORE.Entidades
{
    [Table ("pagos")]
     public class Pago
    {
        [Column("IdPago")]
        [Key]
        public int IdPago { get; set; }

        [Column("id_cuota")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El id de cuota debe ser mayor a 0")]
        public int id_cuota { get; set; }

        [Column("id_personal")]
        [Required]
        [Range(1, int.MaxValue)]
        public int id_personal { get; set; }

        [Column("fecha_pago")]
        [Required]
        [NotFutureDate(ErrorMessage = "La fecha de pago no puede ser futura.")]
        public DateOnly fecha_pago { get; set; }

        [Column("monto")]
        [Required]
        public decimal monto { get; set; }

        [Column("medio_pago")]
        [Required]
        [StringLength(50, ErrorMessage = "Maximo de caracteres 50.")]
        public string medio_pago { get; set; }

        [Column("observacion")]
        [Required]
        [StringLength(300, ErrorMessage = "La observacion no puede superar los 300 caracteres.")]
        public string observacion { get; set; }
    }
}
