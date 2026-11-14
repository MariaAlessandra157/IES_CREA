using System.ComponentModel.DataAnnotations;

namespace IES_CREA.API.DTOs.Academico
{
    public class MateriaCrearDto
    {
        [Required(ErrorMessage = "El nombre de la materia es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(300, ErrorMessage = "La descripción no puede superar los 300 caracteres.")]
        public string? Descripcion { get; set; }
    }
}