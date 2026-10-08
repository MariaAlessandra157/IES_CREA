using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IES_CREA.CORE.Entidades
{
    [Table("cargos")]
    public class Cargo
    {
        [Column("IdCargo")]
        [Key]
        public int IdCargo { get; set; }

        [Column("nombre")]
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Column("descripcion")]
        [Required]
        [StringLength(200)]
        public string Descripcion { get; set; }
    }
}
