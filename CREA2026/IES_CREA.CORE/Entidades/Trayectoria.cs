using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IES_CREA.CORE.Entidades
{
    [Table ("trayectoria-educativa")]
    public class Trayectoria
    {
        [Column("IdTrayectoriaEducativa")]
        [Key]
        public int IdTrayectoria { get; set; }

        [Column("id_alumno")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El id alumno debe ser mayor a 0")]
        public int id_alumno { get; set; }

        [Column("id_institucion")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El id de institucion debe ser mayor a 0")]
        public int id_institucion {  get; set; }

        [Column("id_curso")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El id curso debe ser mayor a 0")]
        public int id_curso { get; set; }

        [Column("division")]
        [Required(ErrorMessage = "La division es oblligatoria")]
        [StringLength(20, ErrorMessage = "La division no debe contener mas de 100 caracteres")]
        public string division { get; set; }

        [Column("ciclo_lectivo")]
        [Required]
        [StringLength(4, ErrorMessage = "El ciclo lectivo no debe contener mas de 4 caracteres")]
        public string ciclo_lectivo { get; set; }

        [Column("fecha_desde")]
        [Required]
        [NotFutureDate(ErrorMessage = "La fecha desde no puede ser futura")]
        public DateOnly fecha_desde { get; set; }

        [Column ("fecha_hasta")]
        [Required]
        [NotFutureDate(ErrorMessage = "La fecha de hasta no puede ser futura")]
        [DateGreaterThan("fecha_desde")]
        public DateOnly fecha_hasta { get; set; }

        [Column ("observaciones")]
        [Required]
        [StringLength(200, ErrorMessage = "La observacion no puede contener mas de 200 caracteres")]
        public string observaciones { get; set; }
    }

    //metodo para validar que la fecha_hasta sea mayor o igual que fecha_desde
    public class DateGreaterThanAttribute : ValidationAttribute
    {
        private readonly string _otherPropertyName;

        public DateGreaterThanAttribute(string otherPropertyName)
        {
            _otherPropertyName = otherPropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var otherProperty = context.ObjectType.GetProperty(_otherPropertyName);

            if (otherProperty == null)
                return new ValidationResult($"La propiedad {_otherPropertyName} no existe.");

            var otherValue = otherProperty.GetValue(context.ObjectInstance);

            if (value is DateOnly fechaHasta && otherValue is DateOnly fechaDesde)
            {
                if (fechaHasta < fechaDesde)
                    return new ValidationResult("La fecha hasta debe ser mayor o igual que la fecha desde.");
            }

            return ValidationResult.Success;
        }
    }

}


