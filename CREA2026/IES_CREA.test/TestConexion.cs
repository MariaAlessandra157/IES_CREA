using System.Data;
using System.Threading.Tasks;
using IES_CREA.CORE.Interfaces.Conexion;
using IES_CREA.infrastructure.Contexto;
using Xunit;

namespace IES_CREA.test
{
    public class TestConexion
    {
        [Fact]
        public async Task TestIConexion()
        {
            // 1. Corregido el nombre (db_crea) y quitados los espacios
            string connectionString = "Server=127.0.0.1;Database=db_crea;User Id=root;Password=;Port=3306;";

            IMyConexion conexion = new MyConexion(connectionString);

            // 2. Corregido el nombre del método a 'obtener...' (minúscula) para que coincida con tu interfaz
            using var conn = await conexion.ObtenerConexionAsync();

            Assert.NotNull(conn);
            Assert.Equal(ConnectionState.Open, conn.State);
        }
    }
}