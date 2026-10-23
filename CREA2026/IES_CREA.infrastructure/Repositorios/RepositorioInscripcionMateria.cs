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
    public class RepositorioInscripcionMateria : RepositorioGenerico<InscripcionMateria>, IRepositorioInscripcionMateria
    {
        public RepositorioInscripcionMateria(IMyConexion conn) : base(conn, "inscripcion-materia")
        {
        }

        public async Task<int> sp_inscripcion_agregar_materia(InscripcionMateria inscripcionMateria)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new
                {
                    p_id_inscripcion = inscripcionMateria.IdInscripcion,
                    p_id_materia = inscripcionMateria.IdMateria,
                    p_fecha_inicio = inscripcionMateria.FechaInicio,
                    p_estado = inscripcionMateria.Estado,
                    inscripcionMateria.IdInscripcion,
                    inscripcionMateria.IdMateria,
                    inscripcionMateria.FechaInicio,
                    inscripcionMateria.Estado
                };
                return await conexion.ExecuteAsync(
                    "sp_inscripcion_agregar_materia",
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

        public async Task<int> sp_inscripcion_quitar_materia(int idInscripcionMateria)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new { p_id = idInscripcionMateria, idInscripcionMateria };
                return await conexion.ExecuteAsync(
                    "sp_inscripcion_quitar_materia",
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

        public async Task<IEnumerable<InscripcionMateria>> sp_inscripcion_materias(int idInscripcion)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new { p_id_inscripcion = idInscripcion, idInscripcion };
                return await conexion.QueryAsync<InscripcionMateria>(
                    "sp_inscripcion_materias",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<InscripcionMateria>();
            }
        }
    }
}

