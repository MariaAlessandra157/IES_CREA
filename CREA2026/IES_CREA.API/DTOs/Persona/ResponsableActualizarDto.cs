using System.ComponentModel.DataAnnotations;

namespace IES_CREA.API.DTOs.Persona
{
    public class ResponsableActualizarDto
    {
        [Required]
        public int IdResponsable { get; set; }

        [Required(ErrorMessage = "El ID de la persona es obligatorio.")]
        public int IdPersona { get; set; }
    }
}