using System.ComponentModel.DataAnnotations;

namespace IES_CREA.API.DTOs.Academico
{
    // En MateriaActualizarDto.cs
    public class MateriaActualizarDto
    {
        [Required]
        public int IdMateria { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(300)]
        public string? Descripcion { get; set; }

        public bool Activo { get; set; } // <-- Agrega esto
    }
}