using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IES_CREA.CORE.Entidades
{
    public class Usuario
    {
        [Key]
        [Required(ErrorMessage = "El campo Número de Usuario es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El campo Número de Usuario debe ser un número entero positivo.")])]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "El campo Número de Persona es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El campo Número de Persona debe ser un número entero positivo.")]
        public int id_persona { get; set; }

        [Required(ErrorMessage = "El Nombre de Usuario es obligatorio.")]
        [StringLength(50, ErrorMessage = "El Nombre de Usuario no puede exceder los 50 caracteres.")]
        [RegularExpression(@"^[a-zA-Z0-9._-]{4,50}$", ErrorMessage = "El Nombre de Usuario solo puede contener letras, números, puntos, guiones bajos y guiones.")]
        public string usuario { get; set; }

        [Required(ErrorMessage = "El hash de la contraseña es obligatorio.")]
        [StringLength(255, ErrorMessage = "El hash de la contraseña no puede exceder los 255 caracteres.")]
        public string password_hash { get; set; }

        [Required]
        [Display(Name = "Activo")]
        public bool activo { get; set; }

        [Required(ErrorMessage = "La fecha de creacion es obligatoria")]
        [NotFutureDate(ErrorMessage = "La fecha de creación no puede ser una fecha futura.")]
        public DateOnly fecha_creacion { get; set; }


        [NotFutureDate(ErrorMessage = "La fecha de último acceso no puede ser una fecha futura.")]
        public DateOnly ultimo_acceso { get; set; }

    }
}
