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
    public class RepositorioAlumno : RepositorioGenerico<Alumno>, IRepositorioAlumnos
    {
        public RepositorioAlumno(IMyConexion conn) : base(conn, "alumno")
        {
        }

        public async Task<int> sp_alumno_insertar(Alumno salumnos)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();

                var parametros = new
                {
                    p_id_persona = salumnos.IdPersona,
                    p_fecha_ingreso = salumnos.FechaIngreso,
                    p_fecha_egreso = salumnos.FechaEgreso,
                    p_activo = salumnos.Activo,
                    p_observacion = salumnos.Observaciones
                };

                return await conexion.ExecuteScalarAsync<int>(
                    "sp_alumno_insertar",
                    parametros,
                    commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return 0;
            }
        }

        public async Task<IEnumerable<Alumno>> sp_alumno_consultar()
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();
                return await conexion.QueryAsync<Alumno>(
                    "sp_alumno_consultar",
                    new { p_id_alumno = (int?)null },
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<Alumno>();
            }
        }

        public async Task<Alumno> sp_alumno_actualizar(Alumno alumno)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();

                var parametros = new
                {
                    p_id_persona = alumno.IdPersona,
                    p_fecha_ingreso = alumno.FechaIngreso,
                    p_fecha_egreso = alumno.FechaEgreso,
                    p_activo = alumno.Activo,
                    p_observacion = alumno.Observaciones,
                    p_id = alumno.IdAlumno
                };

                await conexion.ExecuteAsync(
                    "sp_alumno_actualizar",
                    parametros,
                    commandType: CommandType.StoredProcedure);
                return alumno;
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return alumno;
            }
        }
    }
}
   
