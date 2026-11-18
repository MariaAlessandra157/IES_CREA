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

                var parametros = new
                {
                    p_id_alumno = inscripcion.IdAlumno,
                    p_fecha_inicio = inscripcion.FechaInicio,
                    p_fecha_fin = inscripcion.FechaFin,
                    p_tipo_inscripcion = inscripcion.TipoInscripcion,
                    p_estado = inscripcion.Estado,
                    p_observacion = inscripcion.Observacion
                };

                return await conexion.ExecuteScalarAsync<int>(
                    "sp_inscripcion_crear",
                    parametros,
                    commandType: CommandType.StoredProcedure);
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

                return await conexion.QueryAsync<Inscripcion>(
                    "sp_inscripcion_consultar",
                    new { p_id = (int?)null, p_id_alumno = (int?)null },
                    commandType: CommandType.StoredProcedure);
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

                return await conexion.QueryAsync<Inscripcion>(
                    "sp_inscripcion_consultar",
                    new { p_id = (int?)null, p_id_alumno = (int?)idAlumno },
                    commandType: CommandType.StoredProcedure);
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

                var parametros = new
                {
                    p_fecha_fin = inscripcion.FechaFin,
                    p_tipo_inscripcion = inscripcion.TipoInscripcion,
                    p_estado = inscripcion.Estado,
                    p_observacion = inscripcion.Observacion,
                    p_id = inscripcion.IdInscripcion
                };

                await conexion.ExecuteAsync(
                    "sp_inscripcion_actualizar",
                    parametros,
                    commandType: CommandType.StoredProcedure);
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
