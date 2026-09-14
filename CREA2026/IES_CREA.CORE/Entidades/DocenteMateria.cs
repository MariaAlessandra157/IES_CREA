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
        public int Iddocente { get; set; }

        [Column("IdMateria")]
        [Required]
        public int IdMateria { get; set; }

    }
}
