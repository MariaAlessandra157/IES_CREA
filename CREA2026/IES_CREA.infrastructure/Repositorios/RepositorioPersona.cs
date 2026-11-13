using System.IO;
using Dapper;
using IES_CREA.CORE.Entidades;
using IES_CREA.CORE.Interfaces;
using IES_CREA.CORE.Interfaces.Conexion;
using IES_CREA.infrastructure.Contexto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace IES_CREA.infrastructure.Repositorios
{
    public class RepositorioPersona : RepositorioGenerico<Persona>, IRepositorioPersona
    {
        public RepositorioPersona(IMyConexion conn) : base(conn, "persona")
        {
        }

        // 1. Buscar / Obtener
        public async Task<IEnumerable<Persona>> sp_persona_buscar(string busca_)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();
                var parametros = new { p_busqueda = $"%{busca_}%" };
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

        // 2. Obtener por ID (Adaptado para que devuelva 1 sola persona como pide tu interfaz)
        public async Task<Persona> ObtenerPersonaPorId(int p_id)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();
                var parametros = new { p_id = p_id };
                var resultado = await conexion.QueryFirstOrDefaultAsync<Persona>(
                    "sp_persona_obtener", // Asumo que el SP acepta p_id para filtrar
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
                return resultado;
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return null;
            }
        }

        // 3. Insertar
        public async Task<int> sp_persona_insertar(Persona persona_)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();

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
                    p_fechaAlta = persona_.FechaAlta
                };

                // ExecuteScalarAsync devuelve el primer valor de la primera fila (el ID generado por el SP)
                return await conexion.ExecuteScalarAsync<int>(
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

        // 4. Actualizar
        public async Task<Persona> sp_persona_actualizar(Persona persona_)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();
                var parametros = new
                {
                    p_id = persona_.IdPersona,
                    p_dni = persona_.Dni,
                    p_nombre = persona_.Nombre,
                    p_apellido = persona_.Apellido,
                    p_fechaNacimiento = persona_.FechaNacimiento,
                    p_telefono = persona_.Telefono,
                    p_email = persona_.Email,
                    p_direccion = persona_.Direccion
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

        // 5. Obtener Todos
        public async Task<IEnumerable<Persona>> sp_persona_obtener()
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();
                return await conexion.QueryAsync<Persona>(
                    "sp_persona_obtener",
                    new { p_id = (int?)null }, // Enviamos null para que el SP devuelva todos
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