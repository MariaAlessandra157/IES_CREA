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
    public class RepositorioUsuarioRol : RepositorioGenerico<UsuarioRol>, IRepositorioUsuarioRol
    {
        public RepositorioUsuarioRol(IMyConexion conn) : base(conn, "usuario-rol")
        {
        }

        public async Task<int> sp_usuario_asignar_rol(int idUsuario, int idRol)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new
                {
                    p_id_usuario = idUsuario,
                    p_id_rol = idRol,
                    idUsuario,
                    idRol
                };
                return await conexion.ExecuteAsync(
                    "sp_usuario_asignar_rol",
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

        public async Task<IEnumerable<UsuarioRol>> sp_usuario_quitar_rol(int idRol)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new { p_id_rol = idRol, p_id_usuario = 0, idRol };
                return await conexion.QueryAsync<UsuarioRol>(
                    "sp_usuario_quitar_rol",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<UsuarioRol>();
            }
        }

        public async Task<IEnumerable<UsuarioRol>> sp_usuario_roles(int idUsuario)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new { p_id_usuario = idUsuario, idUsuario };
                return await conexion.QueryAsync<UsuarioRol>(
                    "sp_usuario_roles",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<UsuarioRol>();
            }
        }
    }
}

