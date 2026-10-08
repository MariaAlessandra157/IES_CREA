using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IES_CREA.CORE.Entidades
{
    [Table ("clases")]
    public class Clase
    {
        [Column("IdClase")]
        [Key]
        public int IdClase { get; set; }

        [Column("id_docente")]
        [Required]
        public int IdDocente { get; set; }

        [Column("id_materia")]
        [Required]
        public int IdMateria { get; set; }

        [Column("id_aula")]
        [Required]
        public int IdAula { get; set; }

        [Column("tipo_clase")]
        [Required]
        [StringLength(50)]
        public string TipoClase { get; set; }

        [Column("fecha")]
        [Required]
        public DateOnly Fecha { get; set; }

        [Column("hora_inicio")]
        [Required]
        public TimeOnly HoraInicio { get; set; }

        [Column("hora_fin")]
        [Required]
        public TimeOnly HoraFinal { get; set; }

        [Column("estado")]
        [Display(Name = "estado")]
        public bool Estado { get; set; }

        [Column("observacion")]
        [Required]
        [StringLength (300)]
        public string Observacion { get; set; }

    }
}
