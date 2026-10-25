git using IES_CREA.CORE.Entidades;
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
        Task<IEnumerable<Persona>> ObtenerPersonaPorId(int p_id);

        Task<IEnumerable<Persona>> BuscarPersona(string dni, string nombre, string apellido);

        Task<IEnumerable<Persona>> InsertarPersona(Persona persona);

        Task<IEnumerable<Persona>> ActualizarPersona(int p_id);

    }
}
