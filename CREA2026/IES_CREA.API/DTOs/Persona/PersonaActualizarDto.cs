using System;

namespace IES_CREA.API.DTOs.Persona
{
    public class PersonaActualizarDto
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string? Dni { get; set; }
        public DateOnly? FechaNacimiento { get; set; } // ¡Faltaba!
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? Direccion { get; set; }
        public bool? Activo { get; set; }
    }
}