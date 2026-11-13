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
                using var conexion = await _conn.ObtenerConexionAsync();

                string sql = @"
            INSERT INTO pagos (id_cuota, id_personal, fecha_pago, monto, medio_pago, observacion) 
            VALUES (@IdCuota, @IdPersonal, @FechaPago, @Monto, @MedioPago, @Observacion);
            SELECT LAST_INSERT_ID();";

                var parametros = new
                {
                    IdCuota = pagos.IdCuota,
                    IdPersonal = pagos.IdPersonal,
                    FechaPago = pagos.FechaPago,
                    Monto = pagos.Monto,
                    MedioPago = pagos.MedioPago,
                    Observacion = pagos.Observacion
                };

                return await conexion.ExecuteScalarAsync<int>(sql, parametros);
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
                using var conexion = await _conn.ObtenerConexionAsync();
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

        public async Task<Pago> sp_pago_actualizar(Pago pago)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();

                // Pasamos los parámetros necesarios para actualizar el pago
                var parametros = new
                {
                    p_id_pago = pago.IdPago,
                    p_id_cuota = pago.IdCuota,
                    p_id_personal = pago.IdPersonal,
                    p_fecha_pago = pago.FechaPago,
                    p_monto = pago.Monto,
                    p_medio_pago = pago.MedioPago,
                    p_observacion = pago.Observacion
                };

                await conexion.ExecuteAsync(
                    "sp_pago_actualizar",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );

                return pago; // Devolvemos el objeto actualizado
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return pago;
            }
        }
    }
}

