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
    public class RepositorioClases : RepositorioGenerico<Clase>, IRepositorioClases
    {
        public RepositorioClases(IMyConexion conn) : base(conn, "clases")
        {
        }

        public async Task<int> sp_clase_crear(Clase clases)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new
                {
                    p_id_docente = clases.IdDocente,
                    p_id_materia = clases.IdMateria,
                    p_id_aula = clases.IdAula,
                    p_tipo_clase = clases.TipoClase,
                    p_fecha = clases.Fecha,
                    p_hora_inicio = clases.HoraInicio,
                    p_hora_fin = clases.HoraFinal,
                    p_estado = clases.Estado,
                    p_observacion = clases.Observacion,
                    clases.IdDocente,
                    clases.IdMateria,
                    clases.IdAula,
                    clases.TipoClase,
                    clases.Fecha,
                    clases.HoraInicio,
                    clases.HoraFinal,
                    clases.Estado,
                    clases.Observacion
                };
                return await conexion.ExecuteAsync(
                    "sp_clase_crear",
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

        public async Task<IEnumerable<Clase>> sp_clase_consultar(int idClase)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new { p_id = idClase > 0 ? (int?)idClase : null, idClase };
                return await conexion.QueryAsync<Clase>(
                    "sp_clase_consultar",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<Clase>();
            }
        }

        public async Task<Clase> sp_clase_actualizar(Clase clases)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new
                {
                    p_id = clases.IdClase,
                    p_id_docente = clases.IdDocente,
                    p_id_materia = clases.IdMateria,
                    p_id_aula = clases.IdAula,
                    p_fecha = clases.Fecha,
                    p_hora_inicio = clases.HoraInicio,
                    p_hora_fin = clases.HoraFinal,
                    p_estado = clases.Estado,
                    p_observacion = clases.Observacion,
                    clases.IdClase,
                    clases.IdDocente,
                    clases.IdMateria,
                    clases.IdAula,
                    clases.Fecha,
                    clases.HoraInicio,
                    clases.HoraFinal,
                    clases.Estado,
                    clases.Observacion
                };
                await conexion.ExecuteAsync(
                    "sp_clase_actualizar",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
                return clases;
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return clases;
            }
        }
    }
}
