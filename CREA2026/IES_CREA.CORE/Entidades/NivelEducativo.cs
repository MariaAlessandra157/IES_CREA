using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IES_CREA.CORE.Entidades
{
    [Table("nivel-educativo")]
    public class NivelEducativo
    {
        [Column("IdNivelEducativo")]
        [Key]
        public int IdNivelEducativo { get; set; }

        [Column("nombre")]
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Column("descripcion")]
        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

    }
}
