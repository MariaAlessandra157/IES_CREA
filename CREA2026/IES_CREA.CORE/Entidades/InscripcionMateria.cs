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
        [Range(1, int.MaxValue)]
        public int IdInscripcion { get; set; }

        [Column("id_materia")]
        [Required]
        [Range(1, int.MaxValue)]
        public int IdMateria { get; set; }

        [Column("fecha_inicio")]
        [Required(ErrorMessage = "La fecha de inicio es obligatoria.")]
        public DateOnly FechaInicio { get; set; }

        [Column("fecha_fin")]
        [NotFutureDate(ErrorMessage = "La fecha de fin no puede ser futura.")]
        [DateGreaterThan("fecha_inicio")]
        public DateOnly FechaFin { get; set; }
        
        [Column("estado")]
        [Display(Name = "estado")]
        public bool Estado { get; set; }

    }
}
