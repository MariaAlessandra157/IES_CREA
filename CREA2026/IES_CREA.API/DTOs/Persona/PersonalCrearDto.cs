using System;
using System.ComponentModel.DataAnnotations;

namespace IES_CREA.API.DTOs.Persona
{
    public class PersonalCrearDto
    {
        [Required(ErrorMessage = "El ID de la persona es obligatorio.")]
        [Range(1, int.MaxValue)]
        public int IdPersona { get; set; }

        [Required(ErrorMessage = "El ID del cargo es obligatorio.")]
        [Range(1, int.MaxValue)]
        public int IdCargo { get; set; }

        [Required(ErrorMessage = "La fecha de ingreso es obligatoria.")]
        public DateOnly FechaIngreso { get; set; }
    }
}