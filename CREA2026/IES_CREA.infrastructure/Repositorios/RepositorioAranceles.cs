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
    public class RepositorioAranceles : RepositorioGenerico<Arancel>, IRepositorioAranceles
    {
        public RepositorioAranceles(IMyConexion conn) : base(conn, "arancel")
        {
        }

        public async Task<IEnumerable<Arancel>> sp_arancel_listado()
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                return await conexion.QueryAsync<Arancel>(
                    "sp_arancel_listado",
                    new { p_id = (int?)null },
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<Arancel>();
            }
        }

        public async Task<int> sp_arancel_insertar(Arancel aranceles)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new
                {
                    p_nombre = aranceles.Nombre,
                    p_descripcion = aranceles.Descripcion,
                    p_monto = aranceles.Monto,
                    p_fecha_desde = aranceles.FechaVigenciaDesde,
                    p_fecha_hasta = aranceles.FechaVigenciaHasta,
                    p_activo = aranceles.Activo,
                    aranceles.Nombre,
                    aranceles.Descripcion,
                    aranceles.Monto,
                    aranceles.FechaVigenciaDesde,
                    aranceles.FechaVigenciaHasta,
                    aranceles.Activo
                };
                return await conexion.ExecuteAsync(
                    "sp_arancel_insertar",
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

        public async Task<Arancel> sp_arancel_actualizar(Arancel aranceles)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new
                {
                    p_id = aranceles.IdArancel,
                    p_nombre = aranceles.Nombre,
                    p_descripcion = aranceles.Descripcion,
                    p_monto = aranceles.Monto,
                    p_fecha_hasta = aranceles.FechaVigenciaHasta,
                    p_activo = aranceles.Activo,
                    aranceles.IdArancel,
                    aranceles.Nombre,
                    aranceles.Descripcion,
                    aranceles.Monto,
                    aranceles.FechaVigenciaHasta,
                    aranceles.Activo
                };
                await conexion.ExecuteAsync(
                    "sp_arancel_actualizar",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
                return aranceles;
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return aranceles;
            }
        }
    }
}
}