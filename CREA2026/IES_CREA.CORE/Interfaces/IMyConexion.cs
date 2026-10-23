using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace IES_CREA.CORE.Interfaces.Conexion
{
    public interface IMyConexion
    {
        IDbConnection obtenerConexion();
        Task<IDbConnection> obtenerConexionAsync();
    }

}
