using IES_CREA.CORE.Entidades;
using IES_CREA.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IES_CREA.CORE.Servicios
{
    public class ServicioPago
    {
        private readonly IRepositorioPagos _repositorio;
        private readonly IRepositorioCuotas _repositorioCuotas; // Lo inyectamos para actualizar la cuota

        public ServicioPago(IRepositorioPagos repositorio, IRepositorioCuotas repositorioCuotas)
        {
            _repositorio = repositorio;
            _repositorioCuotas = repositorioCuotas;
        }

        // 1. Obtener los pagos de una cuota
        public async Task<IEnumerable<Pago>> ObtenerPagosPorCuotaAsync(int idCuota)
        {
            if (idCuota <= 0) throw new ArgumentException("El ID de la cuota es inválido.");
            return await _repositorio.sp_pagos_cuota(idCuota);
        }

        // 2. Registrar un pago (con reglas de negocio)
        public async Task<int> RegistrarPagoAsync(Pago pago)
        {
            // Regla 1: Validar que tenga cuota y personal
            if (pago.IdCuota <= 0 || pago.IdPersonal <= 0)
            {
                throw new ArgumentException("El pago debe estar asociado a una cuota y a un personal válido.");
            }

            // Regla 2: El monto debe ser mayor a 0
            if (pago.Monto <= 0)
            {
                throw new ArgumentException("El monto del pago debe ser mayor a cero.");
            }

            // Regla 3: La fecha de pago no puede ser futura
            var hoy = DateOnly.FromDateTime(DateTime.Today);
            if (pago.FechaPago > hoy)
            {
                throw new ArgumentException("La fecha de pago no puede ser futura.");
            }

            // 3. Registrar el pago en la base de datos
            var idPagoGenerado = await _repositorio.sp_pago_registrar(pago);

            // 4. ¡Lógica de negocio clave! Actualizar la cuota a "pagada" (estado = true)
            // Buscamos la cuota y la actualizamos. 
            // NOTA: Asegúrate de que tu método sp_cuotas_actualizar acepte el cambio de estado.
            // var cuota = new Cuota { IdCuotas = pago.IdCuota, Estado = true, /* otros campos... */ };
            // await _repositorioCuotas.sp_cuotas_actualizar(cuota);

            return idPagoGenerado;
        }

        // 3. Actualizar un pago (por si se cargó mal el monto)
        public async Task<Pago> ActualizarPagoAsync(int idPago, Pago pago)
        {
            if (idPago <= 0)
                throw new ArgumentException("El ID del pago es inválido.");

            // Asignamos el ID al objeto
            pago.IdPago = idPago;

            // Le pasamos el OBJETO, no el ID
            return await _repositorio.sp_pago_actualizar(pago);
        }
    }
}