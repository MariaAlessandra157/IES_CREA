using IES_CREA.CORE.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Interfaces
{
    public interface IRepositorioAulas
    {
        Task<int> sp_aula_insertar(Aula aulas);
        Task<IEnumerable<Aula>> sp_aula_cosultar(string busca_);
        Task<Aula> sp_aula_actualizar(Aula aulas);
    }
}
