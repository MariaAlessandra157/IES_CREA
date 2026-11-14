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
    public class RepositorioClases : RepositorioGenerico<Clase>, IRepositorioClases
    {
        public RepositorioClases(IMyConexion conn) : base(conn, "clases")
        {
        }

        public async Task<int> sp_clase_crear(Clase clase)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();

                string sql = @"
            INSERT INTO clases (id_docente, id_materia, id_aula, tipo_clase, fecha, hora_inicio, hora_fin, estado, observacion) 
            VALUES (@IdDocente, @IdMateria, @IdAula, @TipoClase, @Fecha, @HoraInicio, @HoraFinal, @Estado, @Observacion);
            SELECT LAST_INSERT_ID();";

                var parametros = new
                {
                    IdDocente = clase.IdDocente,
                    IdMateria = clase.IdMateria,
                    IdAula = clase.IdAula,
                    TipoClase = clase.TipoClase,
                    Fecha = clase.Fecha,
                    HoraInicio = clase.HoraInicio,
                    HoraFinal = clase.HoraFinal,
                    Estado = clase.Estado,
                    Observacion = clase.Observacion
                };

                return await conexion.ExecuteScalarAsync<int>(sql, parametros);
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return 0;
            }
        }

        public async Task<IEnumerable<Clase>> sp_clase_consultar(int idClase)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();

                string sql;
                object parametros;

                if (idClase > 0)
                {
                    // Usamos AS para que las columnas coincidan con las propiedades de C#
                    sql = @"SELECT 
                        IdClase AS IdClase,
                        id_docente AS IdDocente,
                        id_materia AS IdMateria,
                        id_aula AS IdAula,
                        tipo_clase AS TipoClase,
                        fecha AS Fecha,
                        hora_inicio AS HoraInicio,
                        hora_fin AS HoraFinal,
                        estado AS Estado,
                        observacion AS Observacion
                    FROM clases 
                    WHERE IdClase = @IdClase";
                    parametros = new { IdClase = idClase };
                }
                else
                {
                    sql = @"SELECT 
                        IdClase AS IdClase,
                        id_docente AS IdDocente,
                        id_materia AS IdMateria,
                        id_aula AS IdAula,
                        tipo_clase AS TipoClase,
                        fecha AS Fecha,
                        hora_inicio AS HoraInicio,
                        hora_fin AS HoraFinal,
                        estado AS Estado,
                        observacion AS Observacion
                    FROM clases";
                    parametros = new { };
                }

                return await conexion.QueryAsync<Clase>(sql, parametros);
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<Clase>();
            }
        }

        public async Task<Clase> sp_clase_actualizar(Clase clases)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();

                // Usamos SQL directo para evitar problemas con el SP
                string sql = @"
            UPDATE clases 
            SET id_docente = @IdDocente,
                id_materia = @IdMateria,
                id_aula = @IdAula,
                tipo_clase = @TipoClase,
                fecha = @Fecha,
                hora_inicio = @HoraInicio,
                hora_fin = @HoraFinal,
                estado = @Estado,
                observacion = @Observacion
            WHERE IdClase = @IdClase";

                var parametros = new
                {
                    IdClase = clases.IdClase,
                    IdDocente = clases.IdDocente,
                    IdMateria = clases.IdMateria,
                    IdAula = clases.IdAula,
                    TipoClase = clases.TipoClase,
                    Fecha = clases.Fecha,
                    HoraInicio = clases.HoraInicio,
                    HoraFinal = clases.HoraFinal,
                    Estado = clases.Estado,
                    Observacion = clases.Observacion
                };

                await conexion.ExecuteAsync(sql, parametros);
                return clases;
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return clases;
            }
        }
        public async Task<bool> sp_clase_desactivar(int idClase)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();

                // Borrado lógico: cambiamos el estado a false
                string sql = "UPDATE clases SET estado = 0 WHERE IdClase = @IdClase";

                var filasAfectadas = await conexion.ExecuteAsync(sql, new { IdClase = idClase });

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
