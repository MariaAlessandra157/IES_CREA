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
    public class RepositorioCursos : RepositorioGenerico<Curso>, IRepositorioCursos
    {
        public RepositorioCursos(IMyConexion conn) : base(conn, "curso")
        {
        }

        public async Task<int> sp_curso_insertar(Curso cursos)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new
                {
                    p_id_nivel = cursos.IdNivel,
                    p_nombre = cursos.Nombre,
                    p_orden = cursos.Orden,
                    cursos.IdNivel,
                    cursos.Nombre,
                    cursos.Orden
                };
                return await conexion.ExecuteAsync(
                    "sp_curso_insertar",
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

        public async Task<IEnumerable<Curso>> sp_curso_consultar()
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                return await conexion.QueryAsync<Curso>(
                    "sp_curso_consultar",
                    new { p_id = (int?)null },
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<Curso>();
            }
        }

        public async Task<Curso> sp_curso_actualizar(Curso cursos)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new
                {
                    p_id = cursos.IdCurso,
                    p_id_nivel = cursos.IdNivel,
                    p_nombre = cursos.Nombre,
                    p_orden = cursos.Orden,
                    cursos.IdCurso,
                    cursos.IdNivel,
                    cursos.Nombre,
                    cursos.Orden
                };
                await conexion.ExecuteAsync(
                    "sp_curso_actualizar",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
                return cursos;
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return cursos;
            }
        }
    }
}
*/