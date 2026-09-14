using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IES_CREA.CORE.Entidades
{
    [Table("clase-alumno")]
    public class ClaseAlumno
    {
        [Column("IdClase")]
        [Required]
        public int IdClase { get; set; }

        [Column("IdAlumno")]
        [Required]
        public int IdAlumno { get; set; }

    }
}
