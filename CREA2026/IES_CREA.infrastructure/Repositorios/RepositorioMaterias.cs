using System;
using System.Collections.Generic;
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

        // 1. GET: Obtener todas
        public async Task<IEnumerable<Materia>> sp_materia_consultar()
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();

                string sql = @"
                    SELECT 
                        IdMateria AS IdMateria,
                        nombre AS Nombre,
                        descripcion AS Descripcion,
                        activo AS Activo
                    FROM materias";

                return await conexion.QueryAsync<Materia>(sql);
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<Materia>();
            }
        }

        // 2. POST: Crear y devolver ID
        public async Task<int> sp_materia_insertar(Materia materia)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();

                string sql = @"
                    INSERT INTO materias (nombre, descripcion, activo) 
                    VALUES (@Nombre, @Descripcion, @Activo);
                    SELECT LAST_INSERT_ID();";

                var parametros = new
                {
                    Nombre = materia.Nombre,
                    Descripcion = materia.Descripcion,
                    Activo = materia.Activo
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
        public async Task<Materia> sp_materia_actualizar(Materia materia)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();

                string sql = @"
                    UPDATE materias 
                    SET nombre = @Nombre,
                        descripcion = @Descripcion,
                        activo = @Activo
                    WHERE IdMateria = @IdMateria";

                var parametros = new
                {
                    IdMateria = materia.IdMateria,
                    Nombre = materia.Nombre,
                    Descripcion = materia.Descripcion,
                    Activo = materia.Activo
                };

                await conexion.ExecuteAsync(sql, parametros);
                return materia;
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return materia;
            }
        }

        // 4. DELETE: Borrado lógico
        public async Task<bool> sp_materia_desactivar(int idMateria)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();

                string sql = "UPDATE materias SET activo = 0 WHERE IdMateria = @IdMateria";

                var filasAfectadas = await conexion.ExecuteAsync(sql, new { IdMateria = idMateria });

                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return false;
            }
        }
    }
}