using IES_CREA.CORE.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Interfaces
{
    public interface IRepositorioDocentes
    {
        Task<int> sp_docente_insertar(Docente docente);
        Task<IEnumerable<Docente>>sp_docente_consultar();
        Task<Docente> sp_docente_actualizar(Docente docentes);
    }
}
