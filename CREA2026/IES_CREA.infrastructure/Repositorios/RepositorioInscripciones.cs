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
    public class RepositorioInscripciones : RepositorioGenerico<Inscripcion>, IRepositorioInscripciones
    {
        public RepositorioInscripciones(IMyConexion conn) : base(conn, "inscripcion")
        {
        }

        // 1. POST: Crear y devolver ID
        public async Task<int> sp_inscripcion_crear(Inscripcion inscripcion)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();

                string sql = @"
                    INSERT INTO inscripciones (id_alumno, fecha_inicio, fecha_fin, tipo_inscripcion, estado, observacion) 
                    VALUES (@IdAlumno, @FechaInicio, @FechaFin, @TipoInscripcion, @Estado, @Observacion);
                    SELECT LAST_INSERT_ID();";

                var parametros = new
                {
                    IdAlumno = inscripcion.IdAlumno,
                    FechaInicio = inscripcion.FechaInicio,
                    FechaFin = inscripcion.FechaFin,
                    TipoInscripcion = inscripcion.TipoInscripcion,
                    Estado = inscripcion.Estado,
                    Observacion = inscripcion.Observacion
                };

                return await conexion.ExecuteScalarAsync<int>(sql, parametros);
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return 0;
            }
        }

        // 2. GET: Obtener todas
        public async Task<IEnumerable<Inscripcion>> sp_inscripcion_consultar()
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();

                string sql = @"
                    SELECT 
                        IdInscripcion AS IdInscripcion,
                        id_alumno AS IdAlumno,
                        fecha_inicio AS FechaInicio,
                        fecha_fin AS FechaFin,
                        tipo_inscripcion AS TipoInscripcion,
                        estado AS Estado,
                        observacion AS Observacion
                    FROM inscripciones";

                return await conexion.QueryAsync<Inscripcion>(sql);
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<Inscripcion>();
            }
        }

        // 3. GET: Obtener por alumno
        public async Task<IEnumerable<Inscripcion>> sp_inscripciones_alumno(int idAlumno)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();

                string sql = @"
                    SELECT 
                        IdInscripcion AS IdInscripcion,
                        id_alumno AS IdAlumno,
                        fecha_inicio AS FechaInicio,
                        fecha_fin AS FechaFin,
                        tipo_inscripcion AS TipoInscripcion,
                        estado AS Estado,
                        observacion AS Observacion
                    FROM inscripciones
                    WHERE id_alumno = @IdAlumno";

                return await conexion.QueryAsync<Inscripcion>(sql, new { IdAlumno = idAlumno });
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<Inscripcion>();
            }
        }

        // 4. PUT: Actualizar
        public async Task<Inscripcion> sp_inscripcion_actualizar(Inscripcion inscripcion)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();

                string sql = @"
                    UPDATE inscripciones 
                    SET id_alumno = @IdAlumno,
                        fecha_inicio = @FechaInicio,
                        fecha_fin = @FechaFin,
                        tipo_inscripcion = @TipoInscripcion,
                        estado = @Estado,
                        observacion = @Observacion
                    WHERE IdInscripcion = @IdInscripcion";

                var parametros = new
                {
                    IdInscripcion = inscripcion.IdInscripcion,
                    IdAlumno = inscripcion.IdAlumno,
                    FechaInicio = inscripcion.FechaInicio,
                    FechaFin = inscripcion.FechaFin,
                    TipoInscripcion = inscripcion.TipoInscripcion,
                    Estado = inscripcion.Estado,
                    Observacion = inscripcion.Observacion
                };

                await conexion.ExecuteAsync(sql, parametros);
                return inscripcion;
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return inscripcion;
            }
        }
        public async Task<bool> sp_inscripcion_desactivar(int idInscripcion)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();

                // Borrado lógico: cambiamos el estado a false (0)
                string sql = "UPDATE inscripciones SET estado = 0 WHERE IdInscripcion = @IdInscripcion";

                var filasAfectadas = await conexion.ExecuteAsync(sql, new { IdInscripcion = idInscripcion });

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