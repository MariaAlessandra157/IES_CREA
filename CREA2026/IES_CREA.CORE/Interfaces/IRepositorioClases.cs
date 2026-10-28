using IES_CREA.CORE.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Interfaces
{
    public interface IRepositorioClases
    {
        Task<int> sp_clase_crear(Clase clases);
        Task<IEnumerable<Clase>> sp_clase_consultar(int idClase);
        Task<Clase> sp_clase_actualizar(Clase clases);
    }
}
