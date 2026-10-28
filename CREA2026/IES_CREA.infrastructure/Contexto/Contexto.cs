using System;
using System.Data;
using System.Threading.Tasks;
using MySqlConnector;
using IES_CREA.CORE.Interfaces.Conexion;

namespace IES_CREA.infrastructure.Contexto
{
    public class MyConexion : IMyConexion
    {
        private readonly string _cadenaDeConexion;

        /* el constructor recibe la cadena de conexion desde appsetting.json*/
        public MyConexion(string _cadena)
        {
            _cadenaDeConexion = _cadena;
        }

        /* el siguiente método (sincronico) es para obtener una conexion abierta*/
        public IDbConnection obtenerConexion()
        {
            var conn = new MySqlConnection(_cadenaDeConexion);
            conn.Open();
            return conn;
        }

        /* el siguiente método (asincronico) es para obtener una conexion abierta*/
        public async Task<IDbConnection> obtenerConexionAsync()
        {
            var conn = new MySqlConnection(_cadenaDeConexion);
            await conn.OpenAsync();
            return conn;
        }
    }
}

