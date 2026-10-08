using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IES_CREA.CORE.Entidades
{
    [Table("alumnos")]
    public class Alumno
    {
        [Column("IdAlumno")]
        [Key]
        public int IdAlumno { get; set; }

        [Column("id_persona")]
        [Required]
        public int IdPersona { get; set; }

        [Column("fecha_ingreso")]
        [Required]
        public DateOnly FechaIngreso { get; set; }

        [Column("fecha_egreso")]
        [Required]
        [NotFutureDate]
        public DateOnly FechaEgreso { get; set; }

        [Column("activo")]
        [Display(Name = "activo")]
        public bool Activo { get; set; }

        [Column("observacion")]
        [Required]
        [StringLength(300)]
        public string Observaciones { get; set; }

    }
}
