using System;
using System.ComponentModel.DataAnnotations;

namespace IES_CREA.API.DTOs.Persona
{
    public class DocenteActualizarDto
    {
        [Required]
        public int IdDocente { get; set; }

        [Required(ErrorMessage = "La especialidad es obligatoria.")]
        [StringLength(100)]
        public string Especialidad { get; set; } = string.Empty;

        public bool Activo { get; set; } // <-- Agregado para activar/desactivar
    }
}