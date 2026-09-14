using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IES_CREA.CORE.Entidades
{
    [Table ("personas")]
    public class Persona
    {
        [Column("IdPersona")]
        [Key]
        public int IdPersona { get; set; }

        [Column("dni")]
        [Required (ErrorMessage = "El DNI es obligatorio.")]
        [Display(Name = "DNI")]
        [StringLength(10, MinimumLength = 7, ErrorMessage = "El DNI debe tener 10 caracteres.")]
        [Range(100000000, 9999999999, ErrorMessage = "El DNI debe estar entre 10000000 y 999999999.")]
        public string dni { get; set; }

        [Column("nombre")]
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "Máx. 50 caracteres.")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Column("apellido")]
        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(50, ErrorMessage = "Máx. 50 caracteres.")]
        [Display(Name = "Apellido")]
        public string apellido { get; set; }

        [Column("fechaNacimiento")]
        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        public DateOnly fechaNacimiento { get; set; }

        [Column("telefono")]
        [Required]
        [StringLength(20)]
        [RegularExpression(@"^[1-9]\d{1,3}[1-9]\d{5,7}$", ErrorMessage = "Teléfono inválido. Use código de área sin 0 y número sin 15.")]
        public string telefono { get; set; }

        [Column("email")]
        [Required(ErrorMessage = "El email es obligatorio.")]
        [EmailAddress(ErrorMessage = "El email no es válido.")]
        [StringLength(100, ErrorMessage = "Máx. 100 caracteres.")]
        public string email { get; set; }

        [Column("direccion")]
        [Required]
        [StringLength(100)]
        public string direccion { get; set; }

        [Column("activo")]
        [Display(Name = "Activo")]
        public bool activo { get; set; }

        [Column("fechaAlta")]
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
