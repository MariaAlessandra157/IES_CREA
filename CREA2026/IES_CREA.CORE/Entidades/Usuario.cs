using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IES_CREA.CORE.Entidades
{
    [Table ("usuarios")]
    public class Usuario
    {
        [Column ("IdUsuario")]
        [Key]
        public int IdUsuario { get; set; }

        [Column("id_persona")]
        [Required(ErrorMessage = "El campo Número de Persona es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El campo Número de Persona debe ser un número entero positivo.")]
        public int IdPersona { get; set; }

        [Column("usuario")]
        [Required(ErrorMessage = "El Nombre de Usuario es obligatorio.")]
        [StringLength(50, ErrorMessage = "El Nombre de Usuario no puede exceder los 50 caracteres.")]
        [RegularExpression(@"^[a-zA-Z0-9._-]{4,50}$", ErrorMessage = "El Nombre de Usuario solo puede contener letras, números, puntos, guiones bajos y guiones.")]
        public string NombreUsuario { get; set; }

        [Column("password_hash")]
        [Required(ErrorMessage = "El hash de la contraseña es obligatorio.")]
        [StringLength(255, ErrorMessage = "El hash de la contraseña no puede exceder los 255 caracteres.")]
        public string PasswordHash { get; set; }

        [Column("activo")]
        [Display(Name = "activo")]
        public bool Activo { get; set; }

        [Column("fecha_creacion")]
        [Required(ErrorMessage = "La fecha de creacion es obligatoria")]
        [NotFutureDate(ErrorMessage = "La fecha de creación no puede ser una fecha futura.")]
        public DateOnly FechaCreacion { get; set; }

        [Column("ultimo_accseo")]
        [NotFutureDate(ErrorMessage = "La fecha de último acceso no puede ser una fecha futura.")]
        public DateOnly UltimoAcceso { get; set; }

    }
}
