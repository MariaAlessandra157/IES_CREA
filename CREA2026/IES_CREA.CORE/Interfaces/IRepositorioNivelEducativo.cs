using IES_CREA.CORE.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Interfaces
{
    public interface IRepositorioNivelEducativo
    {
        Task<int> sp_nivel_educativo_insertar(NivelEducativo nivelEducativo);
        Task<IEnumerable<NivelEducativo>> sp_nivel_educativo_consultar(int idNivelEducativo);
        Task<IEnumerable<NivelEducativo>> sp_nivel_educativo_actualizar(NivelEducativo nivelEducativo);
    }

}
