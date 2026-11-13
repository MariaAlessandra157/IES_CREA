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
    public class RepositorioResponsable : RepositorioGenerico<Responsable>, IRepositorioResponsable
    {
        public RepositorioResponsable(IMyConexion conn) : base(conn, "responsable")
        {
        }

        public async Task<int> sp_responsable_insertar(Responsable responsable)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();

                string sql = @"
            INSERT INTO responsable (id_persona) 
            VALUES (@IdPersona);
            SELECT LAST_INSERT_ID();";

                var parametros = new
                {
                    IdPersona = responsable.IdPersona
                };

                return await conexion.ExecuteScalarAsync<int>(sql, parametros);
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return 0;
            }
        }

        public async Task<IEnumerable<Responsable>> sp_responsable_consultar(int idResponsable)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();

                // Si idResponsable es 0, traemos todos; si no, filtramos por ID
                string sql = idResponsable > 0
                    ? "SELECT * FROM responsable WHERE IdResponsable = @IdResponsable"
                    : "SELECT * FROM responsable";

                return await conexion.QueryAsync<Responsable>(sql, new { IdResponsable = idResponsable });
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<Responsable>();
            }
        }

        public async Task<Responsable> sp_responsable_actualizar(Responsable responsable)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();

                // Enviamos los parámetros del objeto
                var parametros = new
                {
                    p_id_responsable = responsable.IdResponsable,
                    p_id_persona = responsable.IdPersona
                };

                await conexion.ExecuteAsync(
                    "sp_responsable_actualizar",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );

                return responsable; // Devolvemos el objeto actualizado
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return responsable;
            }
        }
    }
}
