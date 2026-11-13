using IES_CREA.CORE.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Interfaces
{
    public interface IRepositorioAlumnos
    {
        Task<int>sp_alumno_insertar(Alumno salumnos );
        Task<IEnumerable<Alumno>> sp_alumno_consultar();
        Task<Alumno> sp_alumno_actualizar(Alumno alumno);
    }
}
