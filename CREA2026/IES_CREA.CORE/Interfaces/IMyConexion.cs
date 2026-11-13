using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace IES_CREA.CORE.Interfaces.Conexion
{
    /// <summary>
    /// Proporciona conexiones abiertas a la base de datos.
    /// El consumidor es responsable de liberar la conexión (using / await using).
    /// </summary>
    public interface IMyConexion
    {
        /// <summary>Obtiene una conexión abierta (síncrona).</summary>
        IDbConnection ObtenerConexion();

        /// <summary>Obtiene una conexión abierta (asíncrona).</summary>
        Task<IDbConnection> ObtenerConexionAsync(CancellationToken ct = default);
    }
}