using IES_CREA.CORE.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Interfaces
{
    public interface IRepositorioPersonal
    {
        Task<int> sp_personal_insertar(Personal personal);
        Task<IEnumerable<Personal>> sp_personal_consultar(int idPersonal);
        Task<Personal> sp_personal_actualizar(int idPersonal);
    }
}
