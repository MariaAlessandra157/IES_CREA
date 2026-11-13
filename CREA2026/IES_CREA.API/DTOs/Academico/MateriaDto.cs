namespace IES_CREA.API.DTOs.Academico
{
    public class MateriaDto
    {
        public int IdMateria { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public bool Activo { get; set; }
    }
}