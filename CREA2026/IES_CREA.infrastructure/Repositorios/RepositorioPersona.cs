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

namespace IES_CREA.infrastructure.Repositorios
{
    public class RepositorioPersona : RepositorioGenerico<Persona>, IRepositorioPersona
    {
        public RepositorioPersona(IMyConexion conn) : base(conn, "persona")
        {
        }

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
        }
    }
}
*/