using IES_CREA.CORE.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Interfaces
{
    public interface IRepositorioCargos
    {
        Task<IEnumerable<Cargo>> sp_cargo_listado();
        Task<int> sp_cargo_insertar(Cargo cargos);
        Task<Cargo> sp_cargo_actualizar(Cargo cargos);
    }
}
