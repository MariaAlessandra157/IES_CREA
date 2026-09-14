using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IES_CREA.CORE.Entidades
{
    [Table("inscripcion-materia")]
    public class InscripcionMateria
    {
        [Column("IdInscripcionMateria")]
        [Key]
        public int IdInscripcionMateria { get; set; }

        [Column("id_inscripcion")]
        [Required]
        public int id_inscripcion { get; set; }

        [Column("id_materia")]
        [Required]
        public int id_materia { get; set; }

        [Column("fecha_inicio")]
        [Required]
        [NotFutureDate]
        public DateOnly fecha_inicio { get; set; }

        [Column("fecha_fin")]
        [Required]
        public DateOnly fecha_fin { get; set; }
        
        [Column("estado")]
        [Display(Name = "estado")]
        public bool estado { get; set; }

    }
}
