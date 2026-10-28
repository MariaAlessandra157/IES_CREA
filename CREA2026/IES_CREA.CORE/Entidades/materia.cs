using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IES_CREA.CORE.Entidades
{
    [Table ("materias")]
    public class Materia
    {
        [Column("IdMateria")]
        [Key]
        public int IdMateria { get; set; }

        [Column ("nombre")]
        [Required]
        [StringLength(100, ErrorMessage = "El nombre de la materia no debe superar los 100 caracteres.")]
        public string Nombre { get; set; }

        [Column("descripcion")]
        [StringLength(300)]
        public string Descripcion { get; set; }

        [Column("activo")]
        [Display(Name = "activo")]
        public bool Activo { get; set; }
    }
}
