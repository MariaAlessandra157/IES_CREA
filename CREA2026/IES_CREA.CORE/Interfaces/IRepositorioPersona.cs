using IES_CREA.CORE.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Interfaces
{
    public interface IRepositorioPersona
    {
        Task<IEnumerable<Persona>> ObtenerPersonaPorId(int p_id);

        Task<IEnumerable<Persona>> BuscarPersona(string dni, string nombre, string apellido);

        Task<IEnumerable<Persona>> InsertarPersona(Persona persona);

        Task<IEnumerable<Persona>> ActualizarPersona(int p_id);

        Task<int> sp_persona_insertar(Persona persona_);
        Task<IEnumerable<Persona>> sp_persona_buscar(string busca_);
        Task<Persona> sp_persona_actualizar(Persona persona_);
        Task<IEnumerable<Persona>> sp_persona_obtener();
    }
}