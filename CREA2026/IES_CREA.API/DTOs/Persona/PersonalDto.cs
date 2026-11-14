using System;

namespace IES_CREA.API.DTOs.Persona
{
    public class PersonalDto
    {
        public int IdPersonal { get; set; }
        public int IdPersona { get; set; }
        public int IdCargo { get; set; }
        public DateOnly FechaIngreso { get; set; }
        public bool Activo { get; set; }
    }
}