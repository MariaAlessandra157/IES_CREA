using IES_CREA.CORE.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Interfaces
{
    public interface IRepositorioUsuarioRol
    {
        Task<int> sp_usuario_asignar_rol(int idUsuario, int idRol);
        Task<IEnumerable<UsuarioRol>> sp_usuario_quitar_rol(int idRol);
        Task<IEnumerable<UsuarioRol>> sp_usuario_roles(int idUsuario);
    }
}
