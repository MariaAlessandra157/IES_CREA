using Dapper;
using IES_CREA.CORE.Entidades;
using IES_CREA.CORE.Interfaces;
using IES_CREA.infrastructure.Contexto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IES_CREA.infrastructure.Repositorios
{
    public class RepositorioPersona : IRepositorioPersona
    {
        private readonly IMyConexion _conn;

        public RepositorioPersona(IMyConexion conn)
        {
            _conn = conn;
        }

        // Implementación que devuelve una lista de personas por id (firma de la interfaz)
        public async Task<IEnumerable<Persona>> ObtenerPersonaPorId(int p_id)
        {
            try
            {
                using IDbConnection _conexion = await _conn.obtenerConexionAsync();
                using IDbCommand _comando = _conexion.CreateCommand();
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandText = "sp_persona_obtener";

                IDbDataParameter parametro = _comando.CreateParameter();
                parametro.ParameterName = "@p_id";
                parametro.Value = p_id;
                _comando.Parameters.Add(parametro);

                using IDataReader reader = _comando.ExecuteReader();

                var lista = new List<Persona>();

                while (reader.Read())
                {
                    Persona persona = new Persona
                    {
                        IdPersona = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                        Dni = reader.IsDBNull(1) ? null : reader.GetString(1),
                        Nombre = reader.IsDBNull(2) ? null : reader.GetString(2),
                        Apellido = reader.IsDBNull(3) ? null : reader.GetString(3),
                        FechaNacimiento = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4),
                        Telefono = reader.IsDBNull(5) ? null : reader.GetString(5),
                        Email = reader.IsDBNull(6) ? null : reader.GetString(6),
                        Direccion = reader.IsDBNull(7) ? null : reader.GetString(7),
                        Activo = !reader.IsDBNull(8) && reader.GetBoolean(8),
                        FechaAlta = reader.IsDBNull(9) ? DateTime.MinValue : reader.GetDateTime(9)
                    };

                    lista.Add(persona);
                }

                return lista;
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarErrores(ex);
                throw;
            }
        }

        // Implementación de búsqueda por dni, nombre y apellido (firma de la interfaz)
        public async Task<IEnumerable<Persona>> BuscarPersona(string dni, string nombre, string apellido)
        {
            try
            {
                using IDbConnection _conexion = await _conn.obtenerConexionAsync();
                using IDbCommand _comando = _conexion.CreateCommand();
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandText = "sp_persona_buscar"; // ajuste si el nombre del SP es distinto

                var p1 = _comando.CreateParameter();
                p1.ParameterName = "@p_dni";
                p1.Value = (object)dni ?? DBNull.Value;
                _comando.Parameters.Add(p1);

                var p2 = _comando.CreateParameter();
                p2.ParameterName = "@p_nombre";
                p2.Value = (object)nombre ?? DBNull.Value;
                _comando.Parameters.Add(p2);

                var p3 = _comando.CreateParameter();
                p3.ParameterName = "@p_apellido";
                p3.Value = (object)apellido ?? DBNull.Value;
                _comando.Parameters.Add(p3);

                using IDataReader reader = _comando.ExecuteReader();
                var lista = new List<Persona>();

                while (reader.Read())
                {
                    Persona persona = new Persona
                    {
                        IdPersona = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                        Dni = reader.IsDBNull(1) ? null : reader.GetString(1),
                        Nombre = reader.IsDBNull(2) ? null : reader.GetString(2),
                        Apellido = reader.IsDBNull(3) ? null : reader.GetString(3),
                        FechaNacimiento = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4),
                        Telefono = reader.IsDBNull(5) ? null : reader.GetString(5),
                        Email = reader.IsDBNull(6) ? null : reader.GetString(6),
                        Direccion = reader.IsDBNull(7) ? null : reader.GetString(7),
                        Activo = !reader.IsDBNull(8) && reader.GetBoolean(8),
                        FechaAlta = reader.IsDBNull(9) ? DateTime.MinValue : reader.GetDateTime(9)
                    };

                    lista.Add(persona);
                }

                return lista;
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarErrores(ex);
                throw;
            }
        }

        // Stubs para cumplir la interfaz; implementar la lógica de inserción/actualización según necesidad
        public Task<IEnumerable<Persona>> InsertarPersona(Persona persona)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Persona>> ActualizarPersona(int p_id)
        {
            throw new NotImplementedException();
        }
    }
}
