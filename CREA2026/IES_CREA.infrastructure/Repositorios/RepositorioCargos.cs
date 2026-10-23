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
    public class RepositorioCargos : RepositorioGenerico<Cargo>, IRepositorioCargos
    {
        public RepositorioCargos(IMyConexion conn) : base(conn, "cargo")
        {
        }

        public async Task<IEnumerable<Cargo>> sp_cargo_listado()
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                return await conexion.QueryAsync<Cargo>(
                    "sp_cargo_listado",
                    new { p_id = (int?)null },
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<Cargo>();
            }
        }

        public async Task<int> sp_cargo_insertar(Cargo cargos)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new
                {
                    p_nombre = cargos.Nombre,
                    p_descripcion = cargos.Descripcion,
                    cargos.Nombre,
                    cargos.Descripcion
                };
                return await conexion.ExecuteAsync(
                    "sp_cargo_insertar",
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

        public async Task<Cargo> sp_cargo_actualizar(Cargo cargos)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new
                {
                    p_id = cargos.IdCargo,
                    p_nombre = cargos.Nombre,
                    p_descripcion = cargos.Descripcion,
                    cargos.IdCargo,
                    cargos.Nombre,
                    cargos.Descripcion
                };
                await conexion.ExecuteAsync(
                    "sp_cargo_actualizar",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
                return cargos;
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return cargos;
            }
        }
    }
}

