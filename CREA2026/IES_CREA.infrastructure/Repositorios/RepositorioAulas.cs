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
    public class RepositorioAulas : RepositorioGenerico<Aula>, IRepositorioAulas
    {
        public RepositorioAulas(IMyConexion conn) : base(conn, "aula")
        {
        }

        // 1. GET: Obtener todas o buscar
        public async Task<IEnumerable<Aula>> sp_aula_consultar(string busca_)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();

                string sql = @"
                    SELECT 
                        IdAula AS IdAula,
                        nombre AS Nombre,
                        capacidad AS Capacidad,
                        descripcion AS Descripcion,
                        activo AS Activo
                    FROM aulas";

                if (!string.IsNullOrWhiteSpace(busca_))
                {
                    sql += " WHERE nombre LIKE @Busca";
                    return await conexion.QueryAsync<Aula>(sql, new { Busca = $"%{busca_}%" });
                }

                return await conexion.QueryAsync<Aula>(sql);
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<Aula>();
            }
        }

        // 2. POST: Crear y devolver ID
        public async Task<int> sp_aula_insertar(Aula aulas)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();

                string sql = @"
                    INSERT INTO aulas (nombre, capacidad, descripcion, activo) 
                    VALUES (@Nombre, @Capacidad, @Descripcion, @Activo);
                    SELECT LAST_INSERT_ID();";

                var parametros = new
                {
                    Nombre = aulas.Nombre,
                    Capacidad = aulas.Capacidad,
                    Descripcion = aulas.Descripcion,
                    Activo = aulas.Activo
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
        public async Task<Aula> sp_aula_actualizar(Aula aulas)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();

                string sql = @"
                    UPDATE aulas 
                    SET nombre = @Nombre,
                        capacidad = @Capacidad,
                        descripcion = @Descripcion,
                        activo = @Activo
                    WHERE IdAula = @IdAula";

                var parametros = new
                {
                    IdAula = aulas.IdAula,
                    Nombre = aulas.Nombre,
                    Capacidad = aulas.Capacidad,
                    Descripcion = aulas.Descripcion,
                    Activo = aulas.Activo
                };

                await conexion.ExecuteAsync(sql, parametros);
                return aulas;
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return aulas;
            }
        }

        // 4. DELETE: Borrado lógico (desactivar)
        public async Task<bool> sp_aula_desactivar(int idAula)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();

                string sql = "UPDATE aulas SET activo = 0 WHERE IdAula = @IdAula";
                var filasAfectadas = await conexion.ExecuteAsync(sql, new { IdAula = idAula });

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