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
                using var conexion = await _conn.ObtenerConexionAsync();

                string sql = @"
            INSERT INTO personal (id_persona, id_cargo, fecha_ingreso, activo) 
            VALUES (@IdPersona, @IdCargo, @FechaIngreso, @Activo);
            SELECT LAST_INSERT_ID();";

                var parametros = new
                {
                    IdPersona = personal.IdPersona,
                    IdCargo = personal.IdCargo,
                    FechaIngreso = personal.FechaIngreso,
                    Activo = personal.Activo
                };

                return await conexion.ExecuteScalarAsync<int>(sql, parametros);
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
                using var conexion = await _conn.ObtenerConexionAsync();
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

        public async Task<Personal> sp_personal_actualizar(Personal personal)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();

                // Enviamos TODOS los parámetros necesarios para actualizar
                var parametros = new
                {
                    p_id_personal = personal.IdPersonal,
                    p_id_persona = personal.IdPersona,
                    p_id_cargo = personal.IdCargo,
                    p_fecha_ingreso = personal.FechaIngreso,
                    p_activo = personal.Activo
                };

                await conexion.ExecuteAsync(
                    "sp_personal_actualizar",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );

                return personal; // Devolvemos el objeto actualizado
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return personal;
            }
        }
    }
}
