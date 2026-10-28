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
    public class RepositorioInstitucionEducativa : RepositorioGenerico<Institucion>, IRepositorioInstitucionEducativa
    {
        public RepositorioInstitucionEducativa(IMyConexion conn) : base(conn, "institucion-educativa")
        {
        }

        public async Task<IEnumerable<Institucion>> sp_institucion_insertar(Institucion institucion)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new
                {
                    p_nombre = institucion.Nombre,
                    p_direccion = institucion.Direccion,
                    p_telefono = institucion.Telefono,
                    p_email = institucion.Email,
                    p_activo = institucion.Activo,
                    institucion.Nombre,
                    institucion.Direccion,
                    institucion.Telefono,
                    institucion.Email,
                    institucion.Activo
                };
                return await conexion.QueryAsync<Institucion>(
                    "sp_institucion_insertar",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<Institucion>();
            }
        }

        public async Task<IEnumerable<Institucion>> sp_institucion_consultar(int idInstitucion)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new { p_id = idInstitucion > 0 ? (int?)idInstitucion : null, idInstitucion };
                return await conexion.QueryAsync<Institucion>(
                    "sp_institucion_consultar",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<Institucion>();
            }
        }

        public async Task<Institucion> sp_institucion_actualizar(Institucion institucion)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new
                {
                    p_id = institucion.IdInstitucion,
                    p_nombre = institucion.Nombre,
                    p_direccion = institucion.Direccion,
                    p_telefono = institucion.Telefono,
                    p_email = institucion.Email,
                    p_activo = institucion.Activo,
                    institucion.IdInstitucion,
                    institucion.Nombre,
                    institucion.Direccion,
                    institucion.Telefono,
                    institucion.Email,
                    institucion.Activo
                };
                await conexion.ExecuteAsync(
                    "sp_institucion_actualizar",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
                return institucion;
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return institucion;
            }
        }
    }
}

