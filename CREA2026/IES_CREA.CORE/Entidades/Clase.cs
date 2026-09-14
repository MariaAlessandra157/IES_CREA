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
        public int id_docente { get; set; }

        [Column("id_materia")]
        [Required]
        public int id_materia { get; set; }

        [Column("id_aula")]
        [Required]
        public int id_aula { get; set; }

        [Column("tipo_clase")]
        [Required]
        [StringLength(50)]
        public string tipo_clase { get; set; }

        [Column("fecha")]
        [Required]
        public DateOnly fecha { get; set; }

        [Column("hora_inicio")]
        [Required]
        public TimeOnly hora_inicio { get; set; }

        [Column("hora_fin")]
        [Required]
        public TimeOnly hora_final { get; set; }

        [Column("estado")]
        [Display(Name = "estado")]
        public bool estado { get; set; }

        [Column("observacion")]
        [Required]
        [StringLength (300)]
        public string observacion { get; set; }

    }
}
