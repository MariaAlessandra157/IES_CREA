using IES_CREA.CORE.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IES_CREA.CORE.Interfaces
{
    public interface IRepositorioRoles
    {
        Task<IEnumerable<Rol>> sp_rol_consultar(string busca_);
        Task<IEnumerable<Rol>> sp_rol_actualizar(string busca_);
        Task<int> sp_rol_insertar(Rol rol);
    }
}

