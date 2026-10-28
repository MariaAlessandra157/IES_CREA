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
    public class RepositorioAsistencias : RepositorioGenerico<Asistencia>, IRepositorioAsistencias
    {
        public RepositorioAsistencias(IMyConexion conn) : base(conn, "asistencia")
        {
        }

        public async Task<int> sp_asistencia_registrar(Asistencia asistencias)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new
                {
                    p_id_clase = asistencias.IdClase,
                    p_id_alumno = asistencias.IdAlumno,
                    p_estado = asistencias.Estado,
                    p_observacion = asistencias.Observacion,
                    asistencias.IdClase,
                    asistencias.IdAlumno,
                    asistencias.Estado,
                    asistencias.Observacion
                };
                return await conexion.ExecuteAsync(
                    "sp_asistencia_registrar",
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

        public async Task<IEnumerable<Asistencia>> sp_asistencia_actualizar(string busca_)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new { p_id = busca_, busca_ };
                return await conexion.QueryAsync<Asistencia>(
                    "sp_asistencia_actualizar",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<Asistencia>();
            }
        }

        public async Task<IEnumerable<Asistencia>> sp_asistencias_alumno(string busca_)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new { p_id_alumno = busca_, busca_ };
                return await conexion.QueryAsync<Asistencia>(
                    "sp_asistencias_alumno",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<Asistencia>();
            }
        }
    }
}

