using IES_CREA.CORE.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Interfaces
{

    public interface IRepositorioInstitucionEducativa
    {
        Task<IEnumerable<Institucion>> sp_institucion_insertar(Institucion institucion);
        Task<IEnumerable<Institucion>> sp_institucion_consultar(int idInstitucion);
        Task<Institucion> sp_institucion_actualizar(Institucion institucion);
    }
}
