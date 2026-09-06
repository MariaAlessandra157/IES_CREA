using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace IES_CREA.CORE.Entidades
{
    public class Persona
    {
        [Key]
        public int IdPersona { get; set; }

        [Required (ErrorMessage = "El DNI es obligatorio.")]
        [Display(Name = "DNI")]
        [StringLength(8, MinimumLength = 7, ErrorMessage = "El DNI debe tener 8 caracteres.")]
        [Range(10000000, 99999999, ErrorMessage = "El DNI debe estar entre 10000000 y 99999999.")]
        public string dni { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "Máx. 100 caracteres.")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(100, ErrorMessage = "Máx. 100 caracteres.")]
        [Display(Name = "Apellido")]
        public string apellido { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")
        public DateOnly fechaNacimiento { get; set; }

        [Required]
        [RegularExpression(@"^[1-9]\d{1,3}[1-9]\d{5,7}$", ErrorMessage = "Teléfono inválido. Use código de área sin 0 y número sin 15.")]
        public string telefono { get; set; }

        [Required(ErrorMessage = "El email es obligatorio.")]
        [EmailAddress(ErrorMessage = "El email no es válido.")]
        [StringLength(100, ErrorMessage = "Máx. 100 caracteres.")]
        public string email { get; set; }

        [Display(Name = "Activo")]
        public bool activo { get; set; }

        [Required(ErrorMessage = "La fecha de alta es obligatoria.")]
        [NotFutureDate(ErrorMessage = "La fecha de alta no puede ser una fecha futura.")]
        public DateOnly fechaAlta { get; set; }

    }

    public class NotFutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateOnly dateValue)
            {
                if (dateValue > DateOnly.FromDateTime(DateTime.Now))
                {
                    return new ValidationResult(ErrorMessage ?? "La fecha no puede ser una fecha futura.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
