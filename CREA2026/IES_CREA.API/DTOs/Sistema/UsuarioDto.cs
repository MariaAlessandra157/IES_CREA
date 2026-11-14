using System;

namespace IES_CREA.API.DTOs.Sistema
{
    public class UsuarioDto
    {
        public int IdUsuario { get; set; }
        public int IdPersona { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public bool Activo { get; set; }
        public DateOnly FechaCreacion { get; set; }
        public DateOnly UltimoAcceso { get; set; }
    }
}