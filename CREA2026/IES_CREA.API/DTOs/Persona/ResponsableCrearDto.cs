using System.ComponentModel.DataAnnotations;

namespace IES_CREA.API.DTOs.Persona
{
    public class ResponsableCrearDto
    {
        [Required(ErrorMessage = "El ID de la persona es obligatorio.")]
        [Range(1, int.MaxValue)]
        public int IdPersona { get; set; }
    }
}