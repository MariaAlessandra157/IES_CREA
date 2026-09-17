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
        [Range(1, int.MaxValue)]
        public int id_docente { get; set; }

        [Column("dia_semana")]
        [Required]
        [StringLength(20)]
        public string dia_semana { get; set; }

        [Column("hora_inicio")]
        [Required]
        [TimeRange("09:00", "20:00", ErrorMessage = "La hora de inicio debe estar entre 08:00 y 20:00.")]
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

    //Metodo para validar que la hora este dentro del rango de las 09:00 a 20:00
    public class TimeRangeAttribute : ValidationAttribute
    {
        private readonly TimeOnly _min;
        private readonly TimeOnly _max;

        public TimeRangeAttribute(string min, string max)
        {
            _min = TimeOnly.Parse(min);
            _max = TimeOnly.Parse(max);
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value is TimeOnly hora)
            {
                if (hora < _min || hora > _max)
                    return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }

}
