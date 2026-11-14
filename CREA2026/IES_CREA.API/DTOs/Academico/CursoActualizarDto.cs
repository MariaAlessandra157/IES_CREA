using System.ComponentModel.DataAnnotations;

namespace IES_CREA.API.DTOs.Academico
{
    public class CursoActualizarDto
    {
        [Required]
        public int IdCurso { get; set; }

        [Required]
        public int IdNivel { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(10)]
        public string Orden { get; set; } = string.Empty;
    }
}