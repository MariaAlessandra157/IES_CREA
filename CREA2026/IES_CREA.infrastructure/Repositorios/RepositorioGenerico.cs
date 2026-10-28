using System.Data;
using Dapper;
using IES_CREA.CORE.Interfaces.Conexion;
using IES_CREA.infrastructure.Contexto;

namespace IES_CREA.infrastructure.Repositorios
{
    public class RepositorioGenerico<T> where T : class
    {
        protected readonly IMyConexion _conn;
        private readonly string _nombreTabla;

        public RepositorioGenerico(IMyConexion conn, string nombreTabla)
        {
            _conn = conn;
            _nombreTabla = nombreTabla.ToLower();
        }

        // 1. Consultar todos o por ID (Usa el SP: sp_[entidad]_consultar)
        public async Task<IEnumerable<T>> ConsultarAsync(int? id_ = null)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                return await conexion.QueryAsync<T>(
                    $"sp_{_nombreTabla}_consultar",
                    new { _id = id_ },
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<T>();
            }
        }

        // 2. Obtener por ID (Retorna un único objeto o null)
        public async Task<T?> ObtenerPorIdAsync(int id_)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                return await conexion.QueryFirstOrDefaultAsync<T>(
                    $"sp_{_nombreTabla}_consultar",
                    new { _id = id_ },
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return null;
            }
        }

        // 3. Insertar / Crear (Usa el SP: sp_[entidad]_insertar)
        public async Task<int> InsertarAsync(T entidad_)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                return await conexion.ExecuteScalarAsync<int>(
                    $"sp_{_nombreTabla}_insertar",
                    entidad_,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return 0;
            }
        }

        // 4. Actualizar (Usa el SP: sp_[entidad]_actualizar)
        public async Task<bool> ActualizarAsync(T entidad_)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                int filasAfectadas = await conexion.ExecuteAsync(
                    $"sp_{_nombreTabla}_actualizar",
                    entidad_,
                    commandType: CommandType.StoredProcedure
                );
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
}