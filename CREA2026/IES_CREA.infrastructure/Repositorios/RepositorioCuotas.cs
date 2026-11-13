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
    public class RepositorioCuotas : RepositorioGenerico<Cuota>, IRepositorioCuotas
    {
        public RepositorioCuotas(IMyConexion conn) : base(conn, "cuotas")
        {
        }

        // 1. GET: Obtener las cuotas de una inscripción
        public async Task<IEnumerable<Cuota>> sp_cuotas_inscripcion(int idInscripcion)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();

                string sql = @"
                    SELECT 
                        IdCuotas AS IdCuotas,
                        id_arancel AS IdArancel,
                        id_inscripcion AS IdInscripcion,
                        periodo AS Periodo,
                        monto AS Monto,
                        fecha_vencimiento AS FechaVencimiento,
                        estado AS Estado
                    FROM cuotas
                    WHERE id_inscripcion = @IdInscripcion";

                return await conexion.QueryAsync<Cuota>(sql, new { IdInscripcion = idInscripcion });
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<Cuota>();
            }
        }

        // 2. POST: Generar cuota y devolver ID
        public async Task<int> sp_cuota_generar(Cuota cuotas)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();

                string sql = @"
                    INSERT INTO cuotas (id_arancel, id_inscripcion, periodo, monto, fecha_vencimiento, estado) 
                    VALUES (@IdArancel, @IdInscripcion, @Periodo, @Monto, @FechaVencimiento, @Estado);
                    SELECT LAST_INSERT_ID();";

                var parametros = new
                {
                    IdArancel = cuotas.IdArancel,
                    IdInscripcion = cuotas.IdInscripcion,
                    Periodo = cuotas.Periodo,
                    Monto = cuotas.Monto,
                    FechaVencimiento = cuotas.FechaVencimiento,
                    Estado = cuotas.Estado
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
        public async Task<Cuota> sp_cuotas_actualizar(Cuota cuotas)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();

                string sql = @"
                    UPDATE cuotas 
                    SET monto = @Monto,
                        fecha_vencimiento = @FechaVencimiento,
                        estado = @Estado
                    WHERE IdCuotas = @IdCuotas";

                var parametros = new
                {
                    IdCuotas = cuotas.IdCuotas,
                    Monto = cuotas.Monto,
                    FechaVencimiento = cuotas.FechaVencimiento,
                    Estado = cuotas.Estado
                };

                await conexion.ExecuteAsync(sql, parametros);
                return cuotas;
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return cuotas;
            }
        }

        // 4. DELETE: Borrado lógico
        public async Task<bool> sp_cuota_desactivar(int idCuota)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();

                string sql = "UPDATE cuotas SET estado = 0 WHERE IdCuotas = @IdCuotas";

                var filasAfectadas = await conexion.ExecuteAsync(sql, new { IdCuotas = idCuota });

                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return false;
            }
        }
        // 5. Obtener una cuota por su ID (para validaciones)
        public async Task<Cuota> sp_cuota_obtener_por_id(int idCuota)
        {
            try
            {
                using var conexion = await _conn.ObtenerConexionAsync();

                string sql = @"
            SELECT 
                IdCuotas AS IdCuotas,
                id_arancel AS IdArancel,
                id_inscripcion AS IdInscripcion,
                periodo AS Periodo,
                monto AS Monto,
                fecha_vencimiento AS FechaVencimiento,
                estado AS Estado
            FROM cuotas
            WHERE IdCuotas = @IdCuotas";

                return await conexion.QueryFirstOrDefaultAsync<Cuota>(sql, new { IdCuotas = idCuota })!;
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return null!;
            }
        }
    }
}