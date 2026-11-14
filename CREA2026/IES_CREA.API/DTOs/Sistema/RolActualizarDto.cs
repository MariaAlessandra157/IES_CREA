using System.ComponentModel.DataAnnotations;

namespace IES_CREA.API.DTOs.Sistema
{
    public class RolActualizarDto
    {
        [Required]
        public int IdRol { get; set; }

        [Required(ErrorMessage = "El nombre del rol es obligatorio.")]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(255)]
        public string Descripcion { get; set; } = string.Empty;
    }
}