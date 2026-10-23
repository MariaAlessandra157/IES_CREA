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
    public class RepositorioDocenteMateria : RepositorioGenerico<DocenteMateria>, IRepositorioDocenteMateria
    {
        public RepositorioDocenteMateria(IMyConexion conn) : base(conn, "docente-materia")
        {
        }

        public async Task<IEnumerable<DocenteMateria>> sp_docente_asignar_materia(int idDocente)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new { p_id_docente = idDocente, idDocente };
                return await conexion.QueryAsync<DocenteMateria>(
                    "sp_docente_asignar_materia",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<DocenteMateria>();
            }
        }

        public async Task<IEnumerable<DocenteMateria>> sp_docente_desasignar_materia(int idDocente)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new { p_id_docente = idDocente, idDocente };
                return await conexion.QueryAsync<DocenteMateria>(
                    "sp_docente_desasignar_materia",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<DocenteMateria>();
            }
        }

        public async Task<IEnumerable<DocenteMateria>> sp_docente_materias(int idDocente)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new { p_id_docente = idDocente, idDocente };
                return await conexion.QueryAsync<DocenteMateria>(
                    "sp_docente_materias",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<DocenteMateria>();
            }
        }
    }
}

