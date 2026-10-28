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
    public class RepositorioDisponibilidadDocentes : RepositorioGenerico<DisponibilidadDocente>, IRepositorioDisponibilidadDocente
    {
        public RepositorioDisponibilidadDocentes(IMyConexion conn) : base(conn, "disponibilidad-docente")
        {
        }

        public async Task<int> sp_disponibilidad_registrar(DisponibilidadDocente disponibilidad)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new
                {
                    p_id_docente = disponibilidad.IdDocente,
                    p_dia_semana = disponibilidad.DiaSemana,
                    p_hora_inicio = disponibilidad.HoraInicio,
                    p_hora_fin = disponibilidad.HoraFinal,
                    p_turno = disponibilidad.Turno,
                    p_activo = disponibilidad.Activo,
                    disponibilidad.IdDocente,
                    disponibilidad.DiaSemana,
                    disponibilidad.HoraInicio,
                    disponibilidad.HoraFinal,
                    disponibilidad.Turno,
                    disponibilidad.Activo
                };
                return await conexion.ExecuteAsync(
                    "sp_disponibilidad_registrar",
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

        public async Task<IEnumerable<DisponibilidadDocente>> sp_disponibilidad_docente(int idDocente)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new { p_id_docente = idDocente, idDocente };
                return await conexion.QueryAsync<DisponibilidadDocente>(
                    "sp_disponibilidad_docente",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<DisponibilidadDocente>();
            }
        }

        public async Task<IEnumerable<DisponibilidadDocente>> sp_disponibilidad_actualizar()
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                return await conexion.QueryAsync<DisponibilidadDocente>(
                    "sp_disponibilidad_actualizar",
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<DisponibilidadDocente>();
            }
        }
    }
}
