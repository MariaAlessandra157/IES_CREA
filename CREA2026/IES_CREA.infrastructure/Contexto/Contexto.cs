using System;
using System.Collections.Generic;
using System.Text;
using MySqlConnector;

namespace IES_CREA.infrastructure.Contexto
{
    public class IMyConexion
    {
        private readonly string _cadenaDeConexion;

        /* el constructor recibe la cadena de conexion desde appsetting.json*/
        public IMyConexion(string _cadena)
        {
            _cadenaDeConexion = _cadena;
        }

        /* el siguiente método (sincronico) es para obtener una conexion abierta*/
        public MySqlConnection obtenerConexion()
        {
            MySqlConnection conn = new MySqlConnection(_cadenaDeConexion);
            conn.Open();
            return conn;
        }

        /* el siguiente método (asincronico) es para obtener una conexion abierta*/
        public async Task<MySqlConnection> obtenerConexionAsync()
        {
            MySqlConnection conn = new MySqlConnection(_cadenaDeConexion);
            await conn.OpenAsync();
            return conn;
        }
    }
}
