using IES_CREA.CORE.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Interfaces
{
    public interface IRepositorioInscripcionMateria
    {
        Task<int> sp_inscripcion_agregar_materia(InscripcionMateria inscripcionMateria);
        Task<int> sp_inscripcion_quitar_materia(int idInscripcionMateria);
        Task<IEnumerable<InscripcionMateria>> sp_inscripcion_materias(int idInscripcion);
    }
}
