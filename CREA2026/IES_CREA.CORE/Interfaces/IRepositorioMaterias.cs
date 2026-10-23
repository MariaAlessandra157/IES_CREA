using IES_CREA.CORE.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Interfaces
{
    public interface IRepositorioMaterias               
    {
        Task<int> sp_materia_insertar(Materia materia);
        Task<IEnumerable<Materia>> sp_materia_consultar();
        Task<Materia> sp_materia_actualizar(Materia materia);
    }
}
