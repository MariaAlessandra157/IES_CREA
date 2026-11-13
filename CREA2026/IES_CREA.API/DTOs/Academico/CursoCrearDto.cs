using System.ComponentModel.DataAnnotations;

namespace IES_CREA.API.DTOs.Academico
{
    public class CursoCrearDto
    {
        [Required(ErrorMessage = "El nivel educativo es obligatorio.")]
        public int IdNivel { get; set; }

        [Required(ErrorMessage = "El nombre del curso es obligatorio.")]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El orden es obligatorio.")]
        [StringLength(10)]
        public string Orden { get; set; } = string.Empty;
    }
}