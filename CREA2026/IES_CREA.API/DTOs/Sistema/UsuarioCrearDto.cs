using System.ComponentModel.DataAnnotations;

namespace IES_CREA.API.DTOs.Sistema
{
    public class UsuarioCrearDto
    {
        [Required(ErrorMessage = "El ID de la persona es obligatorio.")]
        [Range(1, int.MaxValue)]
        public int IdPersona { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "El nombre de usuario debe tener entre 4 y 50 caracteres.")]
        [RegularExpression(@"^[a-zA-Z0-9._-]{4,50}$", ErrorMessage = "El nombre de usuario solo puede contener letras, números, puntos, guiones bajos y guiones.")]
        public string NombreUsuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.")]
        public string Password { get; set; } = string.Empty;
    }
}