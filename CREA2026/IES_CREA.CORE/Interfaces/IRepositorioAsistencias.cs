using IES_CREA.CORE.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Interfaces
{
    public interface IRepositorioAsistencias
    {
        Task<int> sp_asistencia_registrar(Asistencia asistencias);
        Task<IEnumerable<Asistencia>> sp_asistencia_actualizar(string busca_);
        Task<IEnumerable<Asistencia>> sp_asistencias_alumno(string busca_);
    }
}
