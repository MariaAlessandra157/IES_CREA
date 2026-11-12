using IES_CREA.CORE.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Interfaces
{
    public interface IRepositorioTrayectoriaEducativa
    {
        Task<int> sp_trayectoria_registrar(Trayectoria trayectoria);
        Task<IEnumerable<Trayectoria>> sp_trayectoria_alumno(int idAlumno);
        Task<Trayectoria> sp_trayectoria_actualizar(Trayectoria trayectoria);
    }
}
