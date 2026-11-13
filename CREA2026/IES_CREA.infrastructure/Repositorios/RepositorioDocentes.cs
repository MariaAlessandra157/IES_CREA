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
    public class RepositorioDocentes : RepositorioGenerico<Docente>, IRepositorioDocentes
    {
        public RepositorioDocentes(IMyConexion conn) : base(conn, "docente")
        {
        }

        public async Task<int> sp_docente_insertar(Docente docente)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();

                string sql = @"
            INSERT INTO docentes (id_persona, especialidad, fecha_alta, activo) 
            VALUES (@IdPersona, @Especialidad, @FechaAlta, @Activo);
            SELECT LAST_INSERT_ID();";

                var parametros = new
                {
                    IdPersona = docente.IdPersona,
                    Especialidad = docente.Especialidad,
                    FechaAlta = docente.FechaAlta,
                    Activo = docente.Activo
                };

                return await conexion.ExecuteScalarAsync<int>(sql, parametros);
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return 0;
            }
        }

        public async Task<IEnumerable<Docente>> sp_docente_consultar()
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();
                return await conexion.QueryAsync<Docente>(
                    "sp_docente_consultar",
                    new { p_id = (int?)null },
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<Docente>();
            }
        }

        public async Task<Docente> sp_docente_actualizar(Docente docentes)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();
                var parametros = new
                {
                    p_id = docentes.IdDocente,
                    p_especialidad = docentes.Especialidad,
                    p_activo = docentes.Activo,
                    docentes.IdDocente,
                    docentes.Especialidad,
                    docentes.Activo
                };
                await conexion.ExecuteAsync(
                    "sp_docente_actualizar",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
                return docentes;
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return docentes;
            }
        }
    }
}
