using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IES_CREA.CORE.Entidades
{
    [Table("personal")]
    public class Personal
    {
        [Column("IdPersonal")]
        [Key]
        public int IdPersonal { get; set; }

        [Column("id_persona")]
        [Required]
        public int id_persona { get; set; }

        [Column("id_cargo")]
        [Required]
        public int id_cargo { get; set; }

        [Column("fecha_ingreso")]
        [Required]
        public DateOnly fecha_ingreso { get; set; }

        [Column("activo")]
        [Display(Name = "activo")]
        public bool activo { get; set; }

    }
}
