using IES_CREA.CORE.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Interfaces
{
    public interface IRepositorioCursos
    {
        Task<int> sp_curso_insertar(Curso cursos);
        Task<IEnumerable<Curso>> sp_curso_consultar();
        Task<Curso> sp_curso_actualizar(Curso cursos);
    }
}
