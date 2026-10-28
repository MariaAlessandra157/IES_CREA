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
    public class RepositorioAulas : RepositorioGenerico<Aula>, IRepositorioAulas
    {
        public RepositorioAulas(IMyConexion conn) : base(conn, "aula")
        {
        }

        public async Task<int> sp_aula_insertar(Aula aulas)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new
                {
                    p_nombre = aulas.Nombre,
                    p_capacidad = aulas.Capacidad,
                    p_descripcion = aulas.Descripcion,
                    p_activo = aulas.Activo,
                    aulas.Nombre,
                    aulas.Capacidad,
                    aulas.Descripcion,
                    aulas.Activo
                };
                return await conexion.ExecuteAsync(
                    "sp_aula_insertar",
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

        public async Task<IEnumerable<Aula>> sp_aula_cosultar(string busca_)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                int.TryParse(busca_, out int idVal);
                var parametros = new { p_id = idVal > 0 ? (int?)idVal : null, busca_ };
                return await conexion.QueryAsync<Aula>(
                    "sp_aula_consultar",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return Enumerable.Empty<Aula>();
            }
        }

        public async Task<Aula> sp_aula_actualizar(Aula aulas)
        {
            try
            {
                using var conexion = await _conn.obtenerConexionAsync();
                var parametros = new
                {
                    p_id = aulas.IdAula,
                    p_nombre = aulas.Nombre,
                    p_capacidad = aulas.Capacidad,
                    p_descripcion = aulas.Descripcion,
                    p_activo = aulas.Activo,
                    aulas.IdAula,
                    aulas.Nombre,
                    aulas.Capacidad,
                    aulas.Descripcion,
                    aulas.Activo
                };
                await conexion.ExecuteAsync(
                    "sp_aula_actualizar",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
                return aulas;
            }
            catch (Exception ex)
            {
                ArchivoLog.RegistrarError(ex);
                return aulas;
            }
        }
    }
}

