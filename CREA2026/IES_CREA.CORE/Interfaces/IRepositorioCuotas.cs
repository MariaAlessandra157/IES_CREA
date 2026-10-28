using IES_CREA.CORE.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace IES_CREA.CORE.Interfaces
{
    public interface IRepositorioCuotas
    {
        Task<int> sp_cuota_generar(Cuota cuotas);
        Task<int> sp_cuotas_inscripcion(int idInscripcion);
        Task<Cuota> sp_cuotas_actualizar(Cuota cuotas);
    }
}
