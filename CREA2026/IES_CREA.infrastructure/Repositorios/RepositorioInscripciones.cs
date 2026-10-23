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

        public async Task<int> sp_inscripcion_crear(Inscripcion inscripcion)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new
                {
                    p_id_alumno = inscripcion.IdAlumno,
                    p_fecha_inicio = inscripcion.FechaInicio,
                    p_fecha_fin = inscripcion.FechaFin,
                    p_tipo_inscripcion = inscripcion.TipoInscripcion,
                    p_estado = inscripcion.Estado,
                    p_observacion = inscripcion.Observacion,
                    inscripcion.IdAlumno,
                    inscripcion.FechaInicio,
                    inscripcion.FechaFin,
                    inscripcion.TipoInscripcion,
                    inscripcion.Estado,
                    inscripcion.Observacion
                };
                return await conexion.ExecuteAsync(
                    "sp_inscripcion_crear",
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

        public async Task<IEnumerable<Inscripcion>> sp_inscripcion_consultar()
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                return await conexion.QueryAsync<Inscripcion>(
                    "sp_inscripcion_consultar",
                    new { p_id = (int?)null },
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<Inscripcion>();
            }
        }

        public async Task<IEnumerable<Inscripcion>> sp_inscripciones_alumno(int idAlumno)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new { p_id_alumno = idAlumno, idAlumno };
                return await conexion.QueryAsync<Inscripcion>(
                    "sp_inscripciones_alumno",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<Inscripcion>();
            }
        }

        public async Task<Inscripcion> sp_inscripcion_actualizar(Inscripcion inscripcion)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new
                {
                    p_id = inscripcion.IdInscripcion,
                    p_fecha_fin = inscripcion.FechaFin,
                    p_tipo_inscripcion = inscripcion.TipoInscripcion,
                    p_estado = inscripcion.Estado,
                    p_observacion = inscripcion.Observacion,
                    inscripcion.IdInscripcion,
                    inscripcion.FechaFin,
                    inscripcion.TipoInscripcion,
                    inscripcion.Estado,
                    inscripcion.Observacion
                };
                await conexion.ExecuteAsync(
                    "sp_inscripcion_actualizar",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
                return inscripcion;
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return inscripcion;
            }
        }
    }
}
*/