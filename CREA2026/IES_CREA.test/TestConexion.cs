using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
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
            string connectionString = "server=127.0.0.1; Database = bd_crea; User Id=root; Password=; Port=3306";
            IMyConexion conexion = new MyConexion(connectionString);

            using var conn = await conexion.obtenerConexionAsync();

            Assert.NotNull(conn);
            Assert.Equal(ConnectionState.Open, conn.State);
        }
    }
}

