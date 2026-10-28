using IES_CREA.CORE.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Interfaces
{
    public interface IRepositorioResponsable
    {
        Task<int> sp_responsable_insertar(Responsable responsable);
        Task<IEnumerable<Responsable>> sp_responsable_consultar(int idResponsable);
        Task<Responsable> sp_responsable_actualizar(int idResponsable);
    }
}
