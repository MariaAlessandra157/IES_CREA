using IES_CREA.CORE.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Interfaces
{
    public interface IRepositorioAlumnoResponsable
    {
        Task<IEnumerable<AlumnoResponsable>> sp_alumno_asignar_responsable(int id_alumno);
        Task<IEnumerable<AlumnoResponsable>> sp_alumno_desasignar_responsable(int id_alumno);
        Task<IEnumerable<AlumnoResponsable>> sp_alumno_responsables(int id_responsable);
    }
}
