using System;
using System.ComponentModel.DataAnnotations;

namespace IES_CREA.API.DTOs.Persona
{
    public class DocenteCrearDto
    {
        [Required(ErrorMessage = "El ID de la persona es obligatorio.")]
        [Range(1, int.MaxValue)]
        public int IdPersona { get; set; }

        [Required(ErrorMessage = "La especialidad es obligatoria.")]
        [StringLength(100)]
        public string Especialidad { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de alta es obligatoria.")]
        public DateOnly FechaAlta { get; set; }
    }
}