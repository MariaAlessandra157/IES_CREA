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
                using var conexion = await _conn.ObtenerConexionAsync();

                string sql = @"
            INSERT INTO usuarios (id_persona, usuario, password_hash, activo, fecha_creacion, ultimo_acceso) 
            VALUES (@IdPersona, @NombreUsuario, @PasswordHash, @Activo, @FechaCreacion, @UltimoAcceso);
            SELECT LAST_INSERT_ID();";

                var parametros = new
                {
                    IdPersona = usuario.IdPersona,
                    NombreUsuario = usuario.NombreUsuario,
                    PasswordHash = usuario.PasswordHash,
                    Activo = usuario.Activo,
                    FechaCreacion = usuario.FechaCreacion,
                    UltimoAcceso = usuario.UltimoAcceso
                };

                return await conexion.ExecuteScalarAsync<int>(sql, parametros);
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
                using var conexion = await _conn.ObtenerConexionAsync();
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
                using var conexion = await _conn.ObtenerConexionAsync();
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

        public async Task<Usuario> sp_usuario_login(string nombreUsuario)
{
    try
    {
        using var conexion = await _conn.ObtenerConexionAsync();
        var parametros = new { p_usuario = nombreUsuario };
        
        // Usamos QueryFirstOrDefaultAsync porque un login devuelve un solo usuario (o null)
        return await conexion.QueryFirstOrDefaultAsync<Usuario>(
            "sp_usuario_login",
            parametros,
            commandType: CommandType.StoredProcedure
        )!;
    }
    catch (Exception ex)
    {
        ArchivoLog.RegistrarError(ex);
        return null!;
    }
}
    }
}
