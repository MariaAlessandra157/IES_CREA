using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace IES_CREA.CORE.Entidades
{
    public class Persona
    {
        [Key]
        public int IdPersona { get; set; }

        [Required (ErrorMessage = "El DNI es obligatorio.")]
        [Display(Name = "DNI")]
        [StringLength(8, MinimumLength = 7, ErrorMessage = "El DNI debe tener 8 caracteres.")]
        [Range(10000000, 99999999, ErrorMessage = "El DNI debe estar entre 10000000 y 99999999.")]
        public string dni { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "Máx. 100 caracteres.")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(100, ErrorMessage = "Máx. 100 caracteres.")]
        [Display(Name = "Apellido")]
        public string apellido { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")
        public DateOnly fechaNacimiento { get; set; }


        public string telefono { get; set; }

        public string email { get; set; }

        public bool activo { get; set; }

        public DateOnly fechaAlta { get; set; }

    }
}
