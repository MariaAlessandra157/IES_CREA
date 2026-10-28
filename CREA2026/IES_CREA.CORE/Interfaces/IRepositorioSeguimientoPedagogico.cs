using IES_CREA.CORE.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Interfaces
{
    public interface IRepositorioSeguimientoPedagogico
    {
        Task<int> sp_seguimientop_registrar(Seguimiento seguimiento);
        Task<IEnumerable<Seguimiento>> sp_seguimientop_alumno(int idAlumno);
        Task<Seguimiento> sp_seguimientop_actualizar(Seguimiento seguimiento);
    }
}
