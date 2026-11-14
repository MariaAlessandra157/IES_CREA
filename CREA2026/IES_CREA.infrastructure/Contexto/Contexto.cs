using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using MySqlConnector;
using IES_CREA.CORE.Interfaces.Conexion;

namespace IES_CREA.infrastructure.Contexto
{
    public class MyConexion : IMyConexion
    {
        private readonly string _cadenaDeConexion;

        public MyConexion(string cadenaDeConexion)
        {
            _cadenaDeConexion = cadenaDeConexion
                ?? throw new ArgumentNullException(nameof(cadenaDeConexion));
        }

        public IDbConnection ObtenerConexion()
        {
            var conn = new MySqlConnection(_cadenaDeConexion);
            try
            {
                conn.Open();
                return conn;
            }
            catch
            {
                conn.Dispose();
                throw;
            }
        }

        public async Task<IDbConnection> ObtenerConexionAsync(CancellationToken ct = default)
        {
            var conn = new MySqlConnection(_cadenaDeConexion);
            try
            {
                await conn.OpenAsync(ct);
                return conn;
            }
            catch
            {
                await conn.DisposeAsync();
                throw;
            }
        }
    }
}
