using IES_CREA.CORE.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Interfaces
{
    public interface IRepositorioClaseAlumno
    {
        Task<int> sp_clase_quitar_alumno(int idClase, int idAlumno);
        Task<int> sp_clase_asignar_alumno(int idClase, int idAlumno);
        Task<IEnumerable<ClaseAlumno>> sp_clase_alumnos(int idAlumno);
    }
}
