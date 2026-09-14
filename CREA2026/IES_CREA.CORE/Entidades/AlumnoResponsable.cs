using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IES_CREA.CORE.Entidades
{
    [Table ("alumno-responsable")]
    public class AlumnoResponsable
    {
        [Column("IdAlumnoResponsable")]
        [Key]
        public int IdAlumnoResponsable { get; set}

        [Column("id_alumno")]
        [Required]
        public int id_alumno {  get; set; }

        [Column("id_responsable")]
        [Required]
        public int id_responsable { get; set; }

        [Column("parentesco")]
        [Required]
        [StringLength(20)]
        public string parentesco { get; set; }

        [Column("esContactoPrincipal")]
        [Display(Name = "ContactoPrincipal")]
        public bool esContactoPrincipal { get; set; }


    }
}
