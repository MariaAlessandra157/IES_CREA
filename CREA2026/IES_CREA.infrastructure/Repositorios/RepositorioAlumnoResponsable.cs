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
    public class RepositorioAlumnoResponsable : RepositorioGenerico<AlumnoResponsable>, IRepositorioAlumnoResponsable
    {
        public RepositorioAlumnoResponsable(IMyConexion conn) : base(conn, "alumno-responsable")
        {
        }

        public async Task<IEnumerable<AlumnoResponsable>> sp_alumno_asignar_responsable(int id_alumno)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new { p_id_alumno = id_alumno, id_alumno };
                return await conexion.QueryAsync<AlumnoResponsable>(
                    "sp_alumno_asignar_responsable",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<AlumnoResponsable>();
            }
        }

        public async Task<IEnumerable<AlumnoResponsable>> sp_alumno_desasignar_responsable(int id_alumno)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new { p_id = id_alumno, p_id_alumno = id_alumno, id_alumno };
                return await conexion.QueryAsync<AlumnoResponsable>(
                    "sp_alumno_desasignar_responsable",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<AlumnoResponsable>();
            }
        }

        public async Task<IEnumerable<AlumnoResponsable>> sp_alumno_responsables(int id_responsable)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new { p_id_alumno = id_responsable, p_id_responsable = id_responsable, id_responsable };
                return await conexion.QueryAsync<AlumnoResponsable>(
                    "sp_alumno_responsables",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<AlumnoResponsable>();
            }
        }
    }
}

