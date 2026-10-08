using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IES_CREA.CORE.Entidades
{
    [Table ("responsable")]
    public class Responsable
    {
        [Column("IdResponsable")]
        [Key]
        public int IdResponsable { get; set; }

        [Column("id_persona")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El id de persona debe ser mayor a 0")]
        public int IdPersona { get; set; }
    }
}
