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
                using var conexion = await _conn.ObtenerConexionAsync();

                string sql = @"
            INSERT INTO seguimiento_pedagogico (id_materia, id_alumno, id_docente, fecha, tema_trabajado, avance, dificultades, recomendacion, observacion) 
            VALUES (@IdMateria, @IdAlumno, @IdDocente, @Fecha, @TemaTrabajado, @Avance, @Dificultades, @Recomendaciones, @Observaciones);
            SELECT LAST_INSERT_ID();";

                var parametros = new
                {
                    IdMateria = seguimiento.IdMateria,
                    IdAlumno = seguimiento.IdAlumno,
                    IdDocente = seguimiento.IdDocente,
                    Fecha = seguimiento.Fecha,
                    TemaTrabajado = seguimiento.TemaTrabajado,
                    Avance = seguimiento.Avance,
                    Dificultades = seguimiento.Dificultades,
                    Recomendaciones = seguimiento.Recomendaciones,
                    Observaciones = seguimiento.Observaciones
                };

                return await conexion.ExecuteScalarAsync<int>(sql, parametros);
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
                using var conexion = await _conn.ObtenerConexionAsync();
                var parametros = new { p_id_alumno = idAlumno };
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
                using var conexion = await _conn.ObtenerConexionAsync();
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
