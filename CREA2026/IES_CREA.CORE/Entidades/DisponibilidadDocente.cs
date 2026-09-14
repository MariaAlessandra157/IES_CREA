using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IES_CREA.CORE.Entidades
{
    [Table("disponibilidad-docente")]
    public class DisponibilidadDocente
    {
        [Column("IdDisponibilidad")]
        [Key]
        public int IdDisponibilidad { get; set; }

        [Column("id_docente")]
        [Required]
        public int id_docente { get; set; }

        [Column("dia_semana")]
        [Required]
        [StringLength(20)]
        public string dia_semana { get; set; }

        [Column("hora_inicio")]
        [Required]
        public TimeOnly hora_inicio { get; set; }

        [Column("hora_fin")]
        [Required]
        public TimeOnly hora_final { get; set; }

        [Column("turno")]
        [Required]
        [StringLength(50)]
        public string turno { get; set; }

        [Column("activo")]
        [Display(Name = "activo")]
        public bool activo { get; set; }
    }
}
