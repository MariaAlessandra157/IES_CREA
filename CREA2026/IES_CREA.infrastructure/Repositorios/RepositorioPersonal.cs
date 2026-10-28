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
    public class RepositorioPersonal : RepositorioGenerico<Personal>, IRepositorioPersonal
    {
        public RepositorioPersonal(IMyConexion conn) : base(conn, "personal")
        {
        }

        public async Task<int> sp_personal_insertar(Personal personal)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new
                {
                    p_id_persona = personal.IdPersona,
                    p_id_cargo = personal.IdCargo,
                    p_fecha_ingreso = personal.FechaIngreso,
                    p_actvio = personal.Activo,
                    p_activo = personal.Activo,
                    personal.IdPersona,
                    personal.IdCargo,
                    personal.FechaIngreso,
                    personal.Activo
                };
                return await conexion.ExecuteAsync(
                    "sp_personal_insertar",
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

        public async Task<IEnumerable<Personal>> sp_personal_consultar(int idPersonal)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new { p_id = idPersonal > 0 ? (int?)idPersonal : null, idPersonal };
                return await conexion.QueryAsync<Personal>(
                    "sp_personal_consultar",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<Personal>();
            }
        }

        public async Task<Personal> sp_personal_actualizar(int idPersonal)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new { p_id = idPersonal, idPersonal };
                await conexion.ExecuteAsync(
                    "sp_personal_actualizar",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
                return (await ObtenerPorIdAsync(idPersonal))!;
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return null!;
            }
        }
    }
}
*/