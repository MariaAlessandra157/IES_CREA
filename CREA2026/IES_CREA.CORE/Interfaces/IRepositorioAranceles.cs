using IES_CREA.CORE.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Interfaces
{
    public interface IRepositorioAranceles
    {
        Task<IEnumerable<Arancel>> sp_arancel_listado();
        Task<int> sp_arancel_insertar(Arancel aranceles);
        Task<Arancel> sp_arancel_actualizar(Arancel aranceles);
    }
}
