using System.ComponentModel.DataAnnotations;

namespace IES_CREA.API.DTOs.Sistema
{
    public class UsuarioActualizarDto
    {
        [Required]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        [StringLength(50, MinimumLength = 4)]
        public string NombreUsuario { get; set; } = string.Empty;

        [StringLength(100, MinimumLength = 6)]
        public string? Password { get; set; } // Opcional: solo si se quiere cambiar

        public bool Activo { get; set; }
    }
}