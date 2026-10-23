using IES_CREA.CORE.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Interfaces
{
    public interface IRepositorioDocenteMateria
    {
        Task<IEnumerable<DocenteMateria>> sp_docente_asignar_materia(int idDocente);
        Task<IEnumerable<DocenteMateria>> sp_docente_desasignar_materia(int idDocente);
        Task<IEnumerable<DocenteMateria>> sp_docente_materias(int idDocente);
    }
}
