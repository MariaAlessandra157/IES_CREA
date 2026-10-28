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
    public class RepositorioUsuarios : RepositorioGenerico<Usuario>, IRepositorioUsuarios
    {
        public RepositorioUsuarios(IMyConexion conn) : base(conn, "usuarios")
        {
        }

        public async Task<int> sp_usuario_crear(Usuario usuario)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new
                {
                    p_id_persona = usuario.IdPersona,
                    p_usuario = usuario.NombreUsuario,
                    p_password_hash = usuario.PasswordHash,
                    p_activo = usuario.Activo,
                    usuario.IdPersona,
                    usuario.NombreUsuario,
                    usuario.PasswordHash,
                    usuario.Activo
                };
                return await conexion.ExecuteAsync(
                    "sp_usuario_crear",
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

        public async Task<IEnumerable<Usuario>> sp_usuario_cosultar(int idUsuario)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new { p_id = idUsuario > 0 ? (int?)idUsuario : null, idUsuario };
                return await conexion.QueryAsync<Usuario>(
                    "sp_usuario_consultar",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<Usuario>();
            }
        }

        public async Task<Usuario> sp_usuario_actualizar(Usuario usuario)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new
                {
                    p_id = usuario.IdUsuario,
                    p_usuario = usuario.NombreUsuario,
                    p_password_hash = usuario.PasswordHash,
                    p_activo = usuario.Activo,
                    usuario.IdUsuario,
                    usuario.NombreUsuario,
                    usuario.PasswordHash,
                    usuario.Activo
                };
                await conexion.ExecuteAsync(
                    "sp_usuario_actualizar",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
                return usuario;
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return usuario;
            }
        }

        public async Task<IEnumerable<Usuario>> sp_usuario_login(bool activo)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new { p_activo = activo, activo, p_usuario = "" };
                return await conexion.QueryAsync<Usuario>(
                    "sp_usuario_login",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<Usuario>();
            }
        }
    }
}
*/