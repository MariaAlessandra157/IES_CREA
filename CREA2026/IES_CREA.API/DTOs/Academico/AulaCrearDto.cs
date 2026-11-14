using System.ComponentModel.DataAnnotations;

namespace IES_CREA.API.DTOs.Academico
{
    public class AulaCrearDto
    {
        [Required(ErrorMessage = "El nombre del aula es obligatorio.")]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La capacidad es obligatoria.")]
        [Range(1, 100, ErrorMessage = "La capacidad debe estar entre 1 y 100.")]
        public int Capacidad { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(255)]
        public string Descripcion { get; set; } = string.Empty;
    }
}