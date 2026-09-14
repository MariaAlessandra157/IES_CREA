using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IES_CREA.CORE.Entidades
{
    [Table("inscripciones")]
    public class Inscripcion
    {
        [Column("IdInscripcion")]
        [Key]
        public int IdInscripcion { get; set; }

        [Column("id_alumno")]
        [Required]
        [Range(1, int.MaxValue)]
        public int id_alumno { get; set; }

        [Column("fecha_inicio")]
        [Required]
        public DateOnly fecha_inicio { get; set; }

        [Column("fecha_fin")]
        [Required]
        public DateOnly fecha_fin { get; set; }

        [Column("tipo_inscripcion")]
        [Required]
        [StringLength(50)]
        public string tipo_inscripcion { get; set; }

        [Column("estado")]
        [Display(Name = "estado")]
        public bool estado { get; set; }

        [Column("observacion")]
        [Required]
        [StringLength(500)]
        public string observacion { get; set; }

    }
}
