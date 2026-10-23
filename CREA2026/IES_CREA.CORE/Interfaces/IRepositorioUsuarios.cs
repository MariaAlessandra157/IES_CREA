using IES_CREA.CORE.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Interfaces
{
    public interface IRepositorioUsuarios
    {
        Task<int> sp_usuario_crear(Usuario usuario);
        Task<IEnumerable<Usuario>> sp_usuario_cosultar(int idUsuario);
        Task<Usuario> sp_usuario_actualizar(Usuario usuario);
        Task<IEnumerable<Usuario>> sp_usuario_login(bool activo);
    }
}
