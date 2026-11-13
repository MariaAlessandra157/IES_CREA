using System;

namespace IES_CREA.API.DTOs.Persona
{
    public class PersonaCrearDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Dni { get; set; } = string.Empty;
        public DateOnly FechaNacimiento { get; set; } // ¡Faltaba!
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
    }
}