using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IES_CREA.CORE.Entidades
{
    [Table("docente-materia")]
    public class DocenteMateria
    {
        [Column("Iddocente")]
        [Required]
        [Range(1, int.MaxValue)]
        public int Iddocente { get; set; }

        [Column("IdMateria")]
        [Required]
        [Range(1, int.MaxValue)]
        public int IdMateria { get; set; }

    }
}
