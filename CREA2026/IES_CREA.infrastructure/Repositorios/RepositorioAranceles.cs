using System;
using System.Collections.Generic;
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

        // 1. GET: Obtener todos
        public async Task<IEnumerable<Arancel>> sp_arancel_listado()
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();

                string sql = @"
                    SELECT 
                        IdArancel AS IdArancel,
                        nombre AS Nombre,
                        descripcion AS Descripcion,
                        monto AS Monto,
                        fecha_vigencia_desde AS FechaVigenciaDesde,
                        fecha_vigencia_hasta AS FechaVigenciaHasta,
                        activo AS Activo
                    FROM aranceles";

                return await conexion.QueryAsync<Arancel>(sql);
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<Arancel>();
            }
        }

        // 2. POST: Crear y devolver ID
        public async Task<int> sp_arancel_insertar(Arancel aranceles)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();

                string sql = @"
                    INSERT INTO aranceles (nombre, descripcion, monto, fecha_vigencia_desde, fecha_vigencia_hasta, activo) 
                    VALUES (@Nombre, @Descripcion, @Monto, @FechaVigenciaDesde, @FechaVigenciaHasta, @Activo);
                    SELECT LAST_INSERT_ID();";

                var parametros = new
                {
                    Nombre = aranceles.Nombre,
                    Descripcion = aranceles.Descripcion,
                    Monto = aranceles.Monto,
                    FechaVigenciaDesde = aranceles.FechaVigenciaDesde,
                    FechaVigenciaHasta = aranceles.FechaVigenciaHasta,
                    Activo = aranceles.Activo
                };

                return await conexion.ExecuteScalarAsync<int>(sql, parametros);
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return 0;
            }
        }

        // 3. PUT: Actualizar
        public async Task<Arancel> sp_arancel_actualizar(Arancel aranceles)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();

                string sql = @"
                    UPDATE aranceles 
                    SET nombre = @Nombre,
                        descripcion = @Descripcion,
                        monto = @Monto,
                        fecha_vigencia_desde = @FechaVigenciaDesde,
                        fecha_vigencia_hasta = @FechaVigenciaHasta,
                        activo = @Activo
                    WHERE IdArancel = @IdArancel";

                var parametros = new
                {
                    IdArancel = aranceles.IdArancel,
                    Nombre = aranceles.Nombre,
                    Descripcion = aranceles.Descripcion,
                    Monto = aranceles.Monto,
                    FechaVigenciaDesde = aranceles.FechaVigenciaDesde,
                    FechaVigenciaHasta = aranceles.FechaVigenciaHasta,
                    Activo = aranceles.Activo
                };

                await conexion.ExecuteAsync(sql, parametros);
                return aranceles;
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return aranceles;
            }
        }

        // 4. DELETE: Borrado lógico
        public async Task<bool> sp_arancel_desactivar(int idArancel)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();

                string sql = "UPDATE aranceles SET activo = 0 WHERE IdArancel = @IdArancel";

                var filasAfectadas = await conexion.ExecuteAsync(sql, new { IdArancel = idArancel });

                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return false;
            }
        }
    }
}
