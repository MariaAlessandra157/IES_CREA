using IES_CREA.CORE.Entidades;
using IES_CREA.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IES_CREA.CORE.Servicios
{
    public class ServicioCuota
    {
        private readonly IRepositorioCuotas _repositorio;

        public ServicioCuota(IRepositorioCuotas repositorio)
        {
            _repositorio = repositorio;
        }

        // 1. Obtener las cuotas de una inscripción
        public async Task<IEnumerable<Cuota>> ObtenerPorInscripcionAsync(int idInscripcion)
        {
            if (idInscripcion <= 0)
                throw new ArgumentException("El ID de inscripción es inválido.");

            return await _repositorio.sp_cuotas_inscripcion(idInscripcion);
        }

        // 2. Generar una cuota (con reglas de negocio)
        public async Task<int> GenerarCuotaAsync(Cuota cuota)
        {
            // Regla 1: Validar datos básicos
            if (cuota.IdArancel <= 0 || cuota.IdInscripcion <= 0)
            {
                throw new ArgumentException("La cuota debe estar asociada a un arancel y a una inscripción válida.");
            }

            // Regla 2: El monto no puede ser negativo
            if (cuota.Monto <= 0)
            {
                throw new ArgumentException("El monto de la cuota debe ser mayor a cero.");
            }

            // Regla 3: El período debe estar presente
            if (string.IsNullOrWhiteSpace(cuota.Periodo))
            {
                throw new ArgumentException("El período (ej: 'Mayo 2026') es obligatorio.");
            }

            return await _repositorio.sp_cuota_generar(cuota);
        }

        // 3. Actualizar estado de cuota (ej: pagada/no pagada)
        public async Task<Cuota> ActualizarCuotaAsync(Cuota cuota)
        {
            if (cuota.IdCuotas <= 0)
            {
                throw new ArgumentException("El ID de la cuota es inválido.");
            }

            return await _repositorio.sp_cuotas_actualizar(cuota);
        }
        // 4. Desactivar (Borrado lógico)
        public async Task<bool> DesactivarCuotaAsync(int idCuota)
        {
            if (idCuota <= 0)
                throw new ArgumentException("El ID de la cuota es inválido.");

            // Regla 1: La cuota debe existir
            var cuota = await _repositorio.sp_cuota_obtener_por_id(idCuota);

            if (cuota == null)
                throw new ArgumentException("La cuota no existe en el sistema.");

            // Regla 2: No se puede desactivar una cuota que ya está inactiva
            if (!cuota.Estado)
                throw new ArgumentException("La cuota ya se encuentra desactivada.");

            // Regla 3: No se puede desactivar una cuota que ya fue pagada
            // (Opcional, si tu sistema considera que "estado = true" significa "pagada")
            // if (cuota.Estado) // Si estado true = pagada
            //     throw new ArgumentException("No se puede desactivar una cuota ya pagada.");

            return await _repositorio.sp_cuota_desactivar(idCuota);
        }
    }
}