namespace IES_CREA.API.DTOs.Academico
{
    public class AulaDto
    {
        public int IdAula { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int Capacidad { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public bool Activo { get; set; }
    }
}