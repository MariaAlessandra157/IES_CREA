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

        // 1. GET: Obtener todos los cursos
        public async Task<IEnumerable<Curso>> sp_curso_consultar()
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();

                string sql = @"
                    SELECT 
                        IdCurso AS IdCurso,
                        id_nivel AS IdNivel,
                        nombre AS Nombre,
                        orden AS Orden
                    FROM cursos";

                return await conexion.QueryAsync<Curso>(sql);
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<Curso>();
            }
        }

        // 2. POST: Crear y devolver ID
        public async Task<int> sp_curso_insertar(Curso cursos)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();

                string sql = @"
                    INSERT INTO cursos (id_nivel, nombre, orden) 
                    VALUES (@IdNivel, @Nombre, @Orden);
                    SELECT LAST_INSERT_ID();";

                var parametros = new
                {
                    IdNivel = cursos.IdNivel,
                    Nombre = cursos.Nombre,
                    Orden = cursos.Orden
                };

                return await conexion.ExecuteScalarAsync<int>(sql, parametros);
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return 0;
            }
        }

        // 3. PUT: Actualizar
        public async Task<Curso> sp_curso_actualizar(Curso cursos)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();

                string sql = @"
                    UPDATE cursos 
                    SET id_nivel = @IdNivel,
                        nombre = @Nombre,
                        orden = @Orden
                    WHERE IdCurso = @IdCurso";

                var parametros = new
                {
                    IdCurso = cursos.IdCurso,
                    IdNivel = cursos.IdNivel,
                    Nombre = cursos.Nombre,
                    Orden = cursos.Orden
                };

                await conexion.ExecuteAsync(sql, parametros);
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