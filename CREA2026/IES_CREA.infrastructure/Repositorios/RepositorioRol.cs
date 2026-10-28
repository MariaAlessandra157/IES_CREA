using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using IES_CREA.CORE.Entidades;
using IES_CREA.CORE.Interfaces;
using IES_CREA.CORE.Interfaces.Conexion;
using IES_CREA.infrastructure.Contexto;

namespace IES_CREA.infrastructure.Repositorios
{
    public class RepositorioRol : RepositorioGenerico<Rol>, IRepositorioRoles
    {
        public RepositorioRol(IMyConexion conn) : base(conn, "roles")
        {
        }

        public async Task<IEnumerable<Rol>> sp_rol_consultar(string busca_)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                int.TryParse(busca_, out int idVal);
                var parametros = new { p_id = idVal > 0 ? (int?)idVal : null, busca_ };
                return await conexion.QueryAsync<Rol>(
                    "sp_rol_consultar",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<Rol>();
            }
        }

        public async Task<IEnumerable<Rol>> sp_rol_actualizar(string busca_)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                int.TryParse(busca_, out int idVal);
                var parametros = new { p_id = idVal > 0 ? (int?)idVal : null, busca_ };
                return await conexion.QueryAsync<Rol>(
                    "sp_rol_actualizar",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<Rol>();
            }
        }

        public async Task<int> sp_rol_insertar(Rol rol)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new
                {
                    p_nombre = rol.Nombre,
                    p_descripcion = rol.Descripcion,
                    rol.Nombre,
                    rol.Descripcion
                };
                return await conexion.ExecuteAsync(
                    "sp_rol_insertar",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return 0;
            }
        }
    }
}
*/