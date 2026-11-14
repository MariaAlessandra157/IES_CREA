using IES_CREA.CORE.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IES_CREA.CORE.Interfaces
{
    public interface IRepositorioAulas
    {
        Task<int> sp_aula_insertar(Aula aulas);
        Task<IEnumerable<Aula>> sp_aula_consultar(string busca_);
        Task<Aula> sp_aula_actualizar(Aula aulas);
        Task<bool> sp_aula_desactivar(int idAula);
    }
}