using IES_CREA.CORE.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Interfaces
{
    public interface IRepositorioInscripciones
    {
        Task<int> sp_inscripcion_crear(Inscripcion inscripcion);
        Task<IEnumerable<Inscripcion>> sp_inscripcion_consultar();
        Task<IEnumerable<Inscripcion>> sp_inscripciones_alumno(int idAlumno);
        Task<Inscripcion> sp_inscripcion_actualizar(Inscripcion inscripcion);
    }
}
