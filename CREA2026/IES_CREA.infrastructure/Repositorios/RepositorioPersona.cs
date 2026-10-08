using IES_CREA.infrastructure.Contexto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;

namespace IES_CREA.infrastructure.Repositorios
{
    public class RepositorioPersona : IRepositorioPersona
    {
        //REVISAR!!!!!
        //Inyeccion de dependencias para la conexion a la base de datos
        //Se debe trabajar con la interfaz RepositorioPersona
        //con los procedimientos almacenados de la base de datos.
        private readonly IMyConexion _conn;

        public RepositorioPersona(IMyConexion conn)
        {
            _conn = conn;
        }
        public async Task<IEnumerable<Persona>> ObtenerTodosAsync()
        {
            using IDbConnection _conexion = await _conn.obtenerConexionAsync();
            using IDbCommand _comando = _conexion.CreateCommand();
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.CommandText = "sp_personas_obtener_todos";

            using IDataReader reader = _comando.ExecuteReader();
            List<Persona> ListaPersonas = new List<Persona>();

            while (reader.Read())
            {
                Persona persona = new Persona();

                persona.IdPersona = reader.GetInt32(0);
                persona.dni = reader.GetString(1);
                persona.nombre = reader.GetString(2);
                persona.FechaNacimiento = reader.GetString(3);
                persona.Telefono = reader.GetString(4);
                persona.Email = reader.GetString(5);
                persona.Direccion = reader.GetString(6);
                persona.activo = reader.GetBoolean(7);
                persona.FechaAlta = reader.GetDateTime(8);

                ListaPersonas.Add(persona);
            }

            return ListaPersonas;
        }
        catch (Exception error)
            {
            ArchivoLog.RegistrarErrores(error);

    }
}
