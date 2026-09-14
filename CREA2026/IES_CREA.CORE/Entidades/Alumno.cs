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
        public int id_persona { get; set; }

        [Column("fecha_ingreso")]
        [Required]
        public DateOnly fecha_ingreso { get; set; }

        [Column("fecha_egreso")]
        [Required]
        [NotFutureDate]
        public DateOnly fecha_egreso { get; set; }

        [Column("activo")]
        [Display(Name = "activo")]
        public bool activo { get; set; }

        [Column("observacion")]
        [Required]
        [StringLength(300)]
        public string observaciones { get; set; }

    }
}
