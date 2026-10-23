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
    public class RepositorioClaseAlumno : RepositorioGenerico<ClaseAlumno>, IRepositorioClaseAlumno
    {
        public RepositorioClaseAlumno(IMyConexion conn) : base(conn, "clase-alumno")
        {
        }

        public async Task<int> sp_clase_asignar_alumno(int idClase, int idAlumno)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new { p_id_clase = idClase, p_id_alumno = idAlumno, idClase, idAlumno };
                return await conexion.ExecuteAsync(
                    "sp_clase_asignar_alumno",
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

        public async Task<int> sp_clase_quitar_alumno(int idClase, int idAlumno)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new { p_id_clase = idClase, p_id_alumno = idAlumno, idClase, idAlumno };
                return await conexion.ExecuteAsync(
                    "sp_clase_quitar_alumno",
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

        public async Task<IEnumerable<ClaseAlumno>> sp_clase_alumnos(int idAlumno)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new { p_id_clase = idAlumno, p_id_alumno = idAlumno, idAlumno, idClase = idAlumno };
                return await conexion.QueryAsync<ClaseAlumno>(
                    "sp_clase_alumnos",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<ClaseAlumno>();
            }
        }
    }
}

