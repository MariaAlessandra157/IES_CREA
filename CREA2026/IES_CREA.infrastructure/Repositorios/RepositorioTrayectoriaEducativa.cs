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
    public class RepositorioTrayectoriaEducativa : RepositorioGenerico<Trayectoria>, IRepositorioTrayectoriaEducativa
    {
        public RepositorioTrayectoriaEducativa(IMyConexion conn) : base(conn, "trayectoria-educativa")
        {
        }

        public async Task<int> sp_trayectoria_registrar(Trayectoria trayectoria)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();

                string sql = @"
            INSERT INTO trayectoria_educativa (id_alumno, id_institucion, id_curso, division, ciclo_lectivo, fecha_desde, fecha_hasta, observaciones) 
            VALUES (@IdAlumno, @IdInstitucion, @IdCurso, @Division, @Ciclolectivo, @FechaDesde, @FechaHasta, @Observaciones);
            SELECT LAST_INSERT_ID();";

                var parametros = new
                {
                    IdAlumno = trayectoria.IdAlumno,
                    IdInstitucion = trayectoria.IdInstitucion,
                    IdCurso = trayectoria.IdCurso,
                    Division = trayectoria.Division,
                    Ciclolectivo = trayectoria.Ciclolectivo,
                    FechaDesde = trayectoria.FechaDesde,
                    FechaHasta = trayectoria.FechaHasta,
                    Observaciones = trayectoria.Observaciones
                };

                return await conexion.ExecuteScalarAsync<int>(sql, parametros);
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return 0;
            }
        }

        public async Task<IEnumerable<Trayectoria>> sp_trayectoria_alumno(int idAlumno)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();
                var parametros = new { p_id_alumno = idAlumno };
                return await conexion.QueryAsync<Trayectoria>(
                    "sp_trayectoria_alumno",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<Trayectoria>();
            }
        }

        public async Task<Trayectoria> sp_trayectoria_actualizar(Trayectoria trayectoria)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();
                var parametros = new
                {
                    p_id = trayectoria.IdTrayectoria,
                    p_id_curso = trayectoria.IdCurso,
                    p_division = trayectoria.Division,
                    p_ciclo_lectivo = trayectoria.Ciclolectivo,
                    p_fecha_desde = trayectoria.FechaDesde,
                    p_fecha_hasta = trayectoria.FechaHasta,
                    p_observaciones = trayectoria.Observaciones,
                    trayectoria.IdTrayectoria,
                    trayectoria.IdCurso,
                    trayectoria.Division,
                    trayectoria.FechaDesde,
                    trayectoria.FechaHasta,
                    trayectoria.Observaciones
                };
                await conexion.ExecuteAsync(
                    "sp_trayectoria_actualizar",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
                return trayectoria;
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return trayectoria;
            }
        }
    }
}
