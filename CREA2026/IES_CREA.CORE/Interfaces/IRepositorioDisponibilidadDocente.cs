using IES_CREA.CORE.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Interfaces
{
    public interface IRepositorioDisponibilidadDocente
    {
        Task<int> sp_disponibilidad_registrar(DisponibilidadDocente disponibilidad);
        Task<IEnumerable<DisponibilidadDocente>> sp_disponibilidad_docente(int idDocente);
        Task<IEnumerable<DisponibilidadDocente>> sp_disponibilidad_actualizar();
    }
}
