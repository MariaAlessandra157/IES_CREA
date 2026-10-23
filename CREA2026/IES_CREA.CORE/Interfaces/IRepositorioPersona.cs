using IES_CREA.CORE.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Interfaces
{
    //REVISAR!!!!!
    //Se debe realizar la interfaz de cada tabla de acuerdo a los procedimientos
    //que se tenga en la base de datos.
    public interface IRepositorioPersona
    {
        Task<int> sp_persona_insertar(Persona persona_);
        Task<IEnumerable<Persona>> sp_persona_buscar(string busca_);
        Task<Persona> sp_persona_actualizar(Persona persona_);
        Task<IEnumerable<Persona>> sp_persona_obtener();
    }
}