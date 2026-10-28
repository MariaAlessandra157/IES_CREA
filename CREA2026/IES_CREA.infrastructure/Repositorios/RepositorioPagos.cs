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
    public class RepositorioPagos : RepositorioGenerico<Pago>, IRepositorioPagos
    {
        public RepositorioPagos(IMyConexion conn) : base(conn, "pago")
        {
        }

        public async Task<int> sp_pago_registrar(Pago pagos)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new
                {
                    p_id_cuota = pagos.IdCuota,
                    p_id_personal = pagos.IdPersonal,
                    p_fecha_pago = pagos.FechaPago,
                    p_monto = pagos.Monto,
                    p_medio_pago = pagos.MedioPago,
                    p_observacion = pagos.Observacion,
                    pagos.IdCuota,
                    pagos.IdPersonal,
                    pagos.FechaPago,
                    pagos.Monto,
                    pagos.MedioPago,
                    pagos.Observacion
                };
                return await conexion.ExecuteAsync(
                    "sp_pago_registar",
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

        public async Task<IEnumerable<Pago>> sp_pagos_cuota(int idCuota)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new { p_id_cuota = idCuota, idCuota };
                return await conexion.QueryAsync<Pago>(
                    "sp_pagos_cuota",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<Pago>();
            }
        }

        public async Task<Pago> sp_pago_actualizar(int idPago)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new { p_id = idPago, idPago };
                await conexion.ExecuteAsync(
                    "sp_pago_actualizar",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
                return (await ObtenerPorIdAsync(idPago))!;
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return null!;
            }
        }
    }
}

