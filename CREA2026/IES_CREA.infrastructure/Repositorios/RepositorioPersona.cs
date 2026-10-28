<<<<<<< HEAD
﻿using Dapper;
using IES_CREA.CORE.Entidades;
using IES_CREA.CORE.Interfaces;
using IES_CREA.infrastructure.Contexto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
=======
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using IES_CREA.CORE.Entidades;
using IES_CREA.CORE.Interfaces;
using IES_CREA.CORE.Interfaces.Conexion;
using IES_CREA.infrastructure.Contexto;
>>>>>>> desarrollo

namespace IES_CREA.infrastructure.Repositorios
{
    public class RepositorioPersona : RepositorioGenerico<Persona>, IRepositorioPersona
    {
<<<<<<< HEAD
        private readonly IMyConexion _conn;

        public RepositorioPersona(IMyConexion conn)
=======
        public RepositorioPersona(IMyConexion conn) : base(conn, "persona")
>>>>>>> desarrollo
        {
        }

<<<<<<< HEAD
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
=======
        public async Task<int> sp_persona_insertar(Persona persona_)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new
                {
                    p_dni = persona_.Dni,
                    p_nombre = persona_.Nombre,
                    p_apellido = persona_.Apellido,
                    p_fechaNacimiento = persona_.FechaNacimiento,
                    p_telefono = persona_.Telefono,
                    p_email = persona_.Email,
                    p_direccion = persona_.Direccion,
                    p_activo = persona_.Activo,
                    p_fechaAlta = persona_.FechaAlta,
                    persona_.Dni,
                    persona_.Nombre,
                    persona_.Apellido,
                    persona_.FechaNacimiento,
                    persona_.Telefono,
                    persona_.Email,
                    persona_.Direccion,
                    persona_.Activo,
                    persona_.FechaAlta
                };
                return await conexion.ExecuteAsync(
                    "sp_persona_insertar",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return 0;
            }
        }

        public async Task<IEnumerable<Persona>> sp_persona_buscar(string busca_)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new { p_busqueda = $"%{busca_}%", busca_ };
                return await conexion.QueryAsync<Persona>(
                    "sp_persona_buscar",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<Persona>();
            }
        }

        public async Task<Persona> sp_persona_actualizar(Persona persona_)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new
                {
                    p_id = persona_.IdPersona,
                    p_dni = persona_.Dni,
                    p_nombre = persona_.Nombre,
                    p_apellido = persona_.Apellido,
                    p_fechaNacimiento = persona_.FechaNacimiento,
                    p_telefono = persona_.Telefono,
                    p_email = persona_.Email,
                    p_direccion = persona_.Direccion,
                    persona_.IdPersona,
                    persona_.Dni,
                    persona_.Nombre,
                    persona_.Apellido,
                    persona_.FechaNacimiento,
                    persona_.Telefono,
                    persona_.Email,
                    persona_.Direccion
                };
                await conexion.ExecuteAsync(
                    "sp_persona_actualizar",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
                return persona_;
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return persona_;
            }
        }

        public async Task<IEnumerable<Persona>> sp_persona_obtener()
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                return await conexion.QueryAsync<Persona>(
                    "sp_persona_obtener",
                    new { p_id = (int?)null },
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<Persona>();
            }
>>>>>>> desarrollo
        }
    }
}
*/