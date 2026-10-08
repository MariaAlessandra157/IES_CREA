using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IES_CREA.CORE.Entidades
{
    [Table("cursos")]
    public class Curso
    {
        [Column("IdCurso")]
        [Key]
        public int IdCurso { get; set; }

        [Column("id_nivel")]
        [Required]
        public int IdNivel { get; set; }

        [Column("nombre")]
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Column("orden")]
        [Required]
        [StringLength(10)]
        public string Orden { get; set; }


    }
}
