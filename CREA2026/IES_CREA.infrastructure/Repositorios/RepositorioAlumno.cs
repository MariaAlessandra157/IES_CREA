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

                string sql = @"
            INSERT INTO alumnos (id_persona, fecha_ingreso, fecha_egreso, activo, observacion) 
            VALUES (@IdPersona, @FechaIngreso, @FechaEgreso, @Activo, @Observaciones);
            SELECT LAST_INSERT_ID();";

                var parametros = new
                {
                    IdPersona = salumnos.IdPersona,
                    FechaIngreso = salumnos.FechaIngreso,
                    FechaEgreso = salumnos.FechaEgreso,
                    Activo = salumnos.Activo,
                    Observaciones = salumnos.Observaciones
                };

                return await conexion.ExecuteScalarAsync<int>(sql, parametros);
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

                // Usamos SQL directo para evitar problemas con el SP
                string sql = @"
            UPDATE alumnos 
            SET id_persona = @IdPersona,
                fecha_ingreso = @FechaIngreso,
                fecha_egreso = @FechaEgreso,
                activo = @Activo,
                observacion = @Observaciones
            WHERE IdAlumno = @IdAlumno";

                var parametros = new
                {
                    IdAlumno = alumno.IdAlumno,
                    IdPersona = alumno.IdPersona,
                    FechaIngreso = alumno.FechaIngreso,
                    FechaEgreso = alumno.FechaEgreso,
                    Activo = alumno.Activo,
                    Observaciones = alumno.Observaciones
                };

                await conexion.ExecuteAsync(sql, parametros);
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
   