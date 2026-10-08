using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IES_CREA.CORE.Entidades
{
    [Table("docentes")]
    public class Docente
    {
        [Column("IdDocente")]
        [Key]
        public int IdDocente { get; set; }

        [Column("id_persona")]
        [Required]
        public int IdPersona { get; set; }

        [Column("especialidad")]
        [Required]
        [StringLength(100)]
        public string Especialidad { get; set; }

        [Column("fecha_alta")]
        [Required]
        public DateOnly FechaAlta { get; set; }

        [Column("activo")]
        [Display(Name = "activo")]
        public bool Activo { get; set; }


    }
}
