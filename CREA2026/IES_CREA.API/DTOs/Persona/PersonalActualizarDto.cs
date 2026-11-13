using System;
using System.ComponentModel.DataAnnotations;

namespace IES_CREA.API.DTOs.Persona
{
    public class PersonalActualizarDto
    {
        [Required]
        public int IdPersonal { get; set; }

        [Required(ErrorMessage = "El ID de la persona es obligatorio.")]
        public int IdPersona { get; set; }

        [Required(ErrorMessage = "El ID del cargo es obligatorio.")]
        public int IdCargo { get; set; }

        [Required(ErrorMessage = "La fecha de ingreso es obligatoria.")]
        public DateOnly FechaIngreso { get; set; }

        public bool Activo { get; set; }
    }
}