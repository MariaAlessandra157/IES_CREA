using System.ComponentModel.DataAnnotations;

namespace IES_CREA.API.DTOs.Sistema
{
    public class RolCrearDto
    {
        [Required(ErrorMessage = "El nombre del rol es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(255, ErrorMessage = "La descripción no puede superar los 255 caracteres.")]
        public string Descripcion { get; set; } = string.Empty;
    }
}