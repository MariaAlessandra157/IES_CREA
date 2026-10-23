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
    public class RepositorioNivelEducativo : RepositorioGenerico<NivelEducativo>, IRepositorioNivelEducativo
    {
        public RepositorioNivelEducativo(IMyConexion conn) : base(conn, "nivel-educativo")
        {
        }

        public async Task<int> sp_nivel_educativo_insertar(NivelEducativo nivelEducativo)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new
                {
                    p_nombre = nivelEducativo.Nombre,
                    p_descripcion = nivelEducativo.Descripcion,
                    nivelEducativo.Nombre,
                    nivelEducativo.Descripcion
                };
                return await conexion.ExecuteAsync(
                    "sp_nivel_educativo_insertar",
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

        public async Task<IEnumerable<NivelEducativo>> sp_nivel_educativo_consultar(int idNivelEducativo)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new { p_id = idNivelEducativo > 0 ? (int?)idNivelEducativo : null, idNivelEducativo };
                return await conexion.QueryAsync<NivelEducativo>(
                    "sp_nivel_educativo_consultar",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<NivelEducativo>();
            }
        }

        public async Task<IEnumerable<NivelEducativo>> sp_nivel_educativo_actualizar(NivelEducativo nivelEducativo)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new
                {
                    p_id = nivelEducativo.IdNivelEducativo,
                    p_nombre = nivelEducativo.Nombre,
                    p_descripcion = nivelEducativo.Descripcion,
                    nivelEducativo.IdNivelEducativo,
                    nivelEducativo.Nombre,
                    nivelEducativo.Descripcion
                };
                return await conexion.QueryAsync<NivelEducativo>(
                    "sp_nivel_educativo_actualizar",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<NivelEducativo>();
            }
        }
    }
}

