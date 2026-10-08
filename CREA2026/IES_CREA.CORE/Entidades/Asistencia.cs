using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IES_CREA.CORE.Entidades
{
    [Table("asistencia")]
    public class Asistencia
    {
        [Column("IdAsistencia")]
        [Key]
        public int IdAsistencia { get; set; }

        [Column("id_clase")]
        [Required]
        public int IdClase { get; set; }

        [Column("id_alumno")]
        [Required]
        public int IdAlumno { get; set; }

        [Column("estado")]
        [Display(Name = "activo")]
        public bool Estado { get; set; }

        [Column("observacion")]
        [Required]
        [StringLength(300)]
        public string Observacion  { get; set; }
    }
}
