using IES_CREA.CORE.Entidades;

namespace IES_CREA.CORE.Interfaces
{
    public interface IRepositorioPersona
    {
        // Consultas
        Task<IEnumerable<Persona>> sp_persona_buscar(string busca_);
        Task<IEnumerable<Persona>> sp_persona_obtener();
        Task<Persona> ObtenerPersonaPorId(int p_id);

        // Acciones
        Task<int> sp_persona_insertar(Persona persona_);
        Task<Persona> sp_persona_actualizar(Persona persona_);
    }
}