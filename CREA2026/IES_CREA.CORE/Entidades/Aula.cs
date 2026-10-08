using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IES_CREA.CORE.Entidades
{
    [Table ("aulas")]
    public class aula
    {
        [Column("IdAula")]
        [Key]
        public int IdAula { get; set; }

        [Column("nombre")]
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Column("capacidad")]
        [Required]
        [Range(1,10)]
        public int Capacidad { get; set; }

        [Column("descripcion")]
        [Required]
        [StringLength (255)]
        public string Descripcion { get; set; }

        [Column("activo")]
        [Display (Name = "activo")]
        public bool Activo { get; set; }


    }
}
