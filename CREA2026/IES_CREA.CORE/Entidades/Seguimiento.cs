using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IES_CREA.CORE.Entidades
{
    [Table ("seguimiento-pedagogico")]
    public class Seguimiento
    {
        [Column ("IdSeguimeinto")]
        [Key]
        public int IdSeguimiento { get; set; }

        [Column("id_materia")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El id de materia debe ser mayor a 0")]
        public int id_materia { get; set; }

        [Column("id_alumno")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El id de alumno debe ser mayor a 0")]
        public int id_alumno { get; set; }

        [Column("id_docente")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El id de dcoente debe ser mayor a 0")]
        public int id_docente { get; set; }

        [Column("fecha")]
        [Required]
        [NotFutureDate(ErrorMessage = "La fecha no puede ser futura")]
        public DateOnly fecha { get; set; }

        [Column("tema_trabajado")]
        [Required]
        [StringLength(300, ErrorMessage = "La descripcion del tema trabajado no debe superar los 300 caracteres")]
        public string tema_trabajo { get; set; }

        [Column("avance")]
        [Required]
        [StringLength(300, ErrorMessage = "La descripcion sobre los avances no puede superar los 300 caracteres.")]
        public string avance { get; set; }

        [Column("dificultades")]
        [Required]
        [StringLength(300, ErrorMessage = "La descripcion sobre las dificultades no debe superar los 300 caracteres.")]
        public string dificultades { get; set; }

        [Column("recomendacion")]
        [Required]
        [StringLength(300, ErrorMessage = "La recomendacion no debe superar los 300 caracteres.")]
        public string recomendaciones { get; set; }

        [Column("observacion")]
        [Required]
        [StringLength(300, ErrorMessage = "Las observaciones no pueden superar los 300 caracteres.")]
        public string observaciones { get; set; }
    }
}
