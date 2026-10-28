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
    public class RepositorioMaterias : RepositorioGenerico<Materia>, IRepositorioMaterias
    {
        public RepositorioMaterias(IMyConexion conn) : base(conn, "materia")
        {
        }

        public async Task<int> sp_materia_insertar(Materia materia)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new
                {
                    p_nombre = materia.Nombre,
                    p_descripcion = materia.Descripcion,
                    p_activo = materia.Activo,
                    materia.Nombre,
                    materia.Descripcion,
                    materia.Activo
                };
                return await conexion.ExecuteAsync(
                    "sp_materia_insertar",
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

        public async Task<IEnumerable<Materia>> sp_materia_consultar()
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                return await conexion.QueryAsync<Materia>(
                    "sp_materia_consultar",
                    new { p_id = (int?)null },
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<Materia>();
            }
        }

        public async Task<Materia> sp_materia_actualizar(Materia materia)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new
                {
                    p_id = materia.IdMateria,
                    p_nombre = materia.Nombre,
                    p_descripcion = materia.Descripcion,
                    p_activo = materia.Activo,
                    materia.IdMateria,
                    materia.Nombre,
                    materia.Descripcion,
                    materia.Activo
                };
                await conexion.ExecuteAsync(
                    "sp_materia_actualizar",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
                return materia;
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return materia;
            }
        }
    }
}
*/