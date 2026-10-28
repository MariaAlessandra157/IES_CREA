using IES_CREA.CORE.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IES_CREA.CORE.Interfaces
{
    public interface IRepositorioPagos
    {
        Task<int> sp_pago_registrar(Pago pagos);
        Task<IEnumerable<Pago>> sp_pagos_cuota(int idCuota);
        Task<Pago> sp_pago_actualizar(int idPago);
    }
}

