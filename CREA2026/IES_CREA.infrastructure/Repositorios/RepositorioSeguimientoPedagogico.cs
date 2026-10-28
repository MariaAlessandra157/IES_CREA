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
    public class RepositorioSeguimientoPedagogico : RepositorioGenerico<Seguimiento>, IRepositorioSeguimientoPedagogico
    {
        public RepositorioSeguimientoPedagogico(IMyConexion conn) : base(conn, "seguimiento-pedagogico")
        {
        }

        public async Task<int> sp_seguimientop_registrar(Seguimiento seguimiento)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new
                {
                    p_id_materia = seguimiento.IdMateria,
                    p_id_alumno = seguimiento.IdAlumno,
                    p_id_docente = seguimiento.IdDocente,
                    p_fecha = seguimiento.Fecha,
                    p_tema_trabajado = seguimiento.TemaTrabajado,
                    p_avance = seguimiento.Avance,
                    p_dificultades = seguimiento.Dificultades,
                    p_recomendacion = seguimiento.Recomendaciones,
                    p_observacion = seguimiento.Observaciones,
                    seguimiento.IdMateria,
                    seguimiento.IdAlumno,
                    seguimiento.IdDocente,
                    seguimiento.Fecha,
                    seguimiento.TemaTrabajado,
                    seguimiento.Avance,
                    seguimiento.Dificultades,
                    seguimiento.Recomendaciones,
                    seguimiento.Observaciones
                };
                return await conexion.ExecuteAsync(
                    "sp_seguimientop_registrar",
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

        public async Task<IEnumerable<Seguimiento>> sp_seguimientop_alumno(int idAlumno)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new { p_id_alumno = idAlumno, idAlumno };
                return await conexion.QueryAsync<Seguimiento>(
                    "sp_seguimientop_alumno",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<Seguimiento>();
            }
        }

        public async Task<Seguimiento> sp_seguimientop_actualizar(Seguimiento seguimiento)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new
                {
                    p_id = seguimiento.IdSeguimiento,
                    p_tema_trabajado = seguimiento.TemaTrabajado,
                    p_avance = seguimiento.Avance,
                    p_dificultades = seguimiento.Dificultades,
                    p_recomendacion = seguimiento.Recomendaciones,
                    p_observacion = seguimiento.Observaciones,
                    seguimiento.IdSeguimiento,
                    seguimiento.TemaTrabajado,
                    seguimiento.Avance,
                    seguimiento.Dificultades,
                    seguimiento.Recomendaciones,
                    seguimiento.Observaciones
                };
                await conexion.ExecuteAsync(
                    "sp_seguimientop_actualizar",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
                return seguimiento;
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return seguimiento;
            }
        }
    }
}
*/