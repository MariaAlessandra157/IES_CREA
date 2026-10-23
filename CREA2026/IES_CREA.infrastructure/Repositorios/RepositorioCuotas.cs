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
    public class RepositorioCuotas : RepositorioGenerico<Cuota>, IRepositorioCuotas
    {
        public RepositorioCuotas(IMyConexion conn) : base(conn, "cuotas")
        {
        }

        public async Task<int> sp_cuota_generar(Cuota cuotas)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new
                {
                    p_id_arancel = cuotas.IdArancel,
                    p_id_inscripcion = cuotas.IdInscripcion,
                    p_periodo = cuotas.Periodo,
                    p_monto = cuotas.Monto,
                    p_fecha_vencimiento = cuotas.FechaVencimiento,
                    p_estado = cuotas.Estado,
                    cuotas.IdArancel,
                    cuotas.IdInscripcion,
                    cuotas.Periodo,
                    cuotas.Monto,
                    cuotas.FechaVencimiento,
                    cuotas.Estado
                };
                return await conexion.ExecuteAsync(
                    "sp_cuota_generar",
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

        public async Task<int> sp_cuotas_inscripcion(int idInscripcion)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new { p_id_inscripcion = idInscripcion, idInscripcion };
                var resultado = await conexion.QueryAsync<Cuota>(
                    "sp_cuotas_incripcion",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
                return resultado.Count();
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return 0;
            }
        }

        public async Task<Cuota> sp_cuotas_actualizar(Cuota cuotas)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new
                {
                    p_id = cuotas.IdCuotas,
                    p_monto = cuotas.Monto,
                    p_fecha_vencimiento = cuotas.FechaVencimiento,
                    p_estado = cuotas.Estado,
                    cuotas.IdCuotas,
                    cuotas.Monto,
                    cuotas.FechaVencimiento,
                    cuotas.Estado
                };
                await conexion.ExecuteAsync(
                    "sp_cuota_actualizar",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
                return cuotas;
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return cuotas;
            }
        }
    }
}
