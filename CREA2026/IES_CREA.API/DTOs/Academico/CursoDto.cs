namespace IES_CREA.API.DTOs.Academico
{
    public class CursoDto
    {
        public int IdCurso { get; set; }
        public int IdNivel { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Orden { get; set; } = string.Empty;
    }
}