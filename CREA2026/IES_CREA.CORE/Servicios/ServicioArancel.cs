using IES_CREA.CORE.Entidades;
using IES_CREA.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IES_CREA.CORE.Servicios
{
    public class ServicioArancel
    {
        private readonly IRepositorioAranceles _repositorio;

        public ServicioArancel(IRepositorioAranceles repositorio)
        {
            _repositorio = repositorio;
        }

        // 1. Obtener todos los aranceles
        public async Task<IEnumerable<Arancel>> ObtenerArancelesAsync()
        {
            return await _repositorio.sp_arancel_listado();
        }

        // 2. Crear un arancel (con reglas de negocio)
        public async Task<int> CrearArancelAsync(Arancel arancel)
        {
            // Regla 1: El monto no puede ser negativo
            if (arancel.Monto < 0)
            {
                throw new ArgumentException("El monto del arancel no puede ser negativo.");
            }

            // Regla 2: La fecha de vigencia hasta no puede ser anterior a la fecha desde
            if (arancel.FechaVigenciaHasta < arancel.FechaVigenciaDesde)
            {
                throw new ArgumentException("La fecha de vigencia 'hasta' no puede ser anterior a la fecha 'desde'.");
            }

            // Regla 3: El nombre es obligatorio
            if (string.IsNullOrWhiteSpace(arancel.Nombre))
            {
                throw new ArgumentException("El nombre del arancel es obligatorio.");
            }

            return await _repositorio.sp_arancel_insertar(arancel);
        }

        // 3. Actualizar un arancel
        public async Task<Arancel> ActualizarArancelAsync(Arancel arancel)
        {
            if (arancel.IdArancel <= 0)
            {
                throw new ArgumentException("El ID del arancel es inválido.");
            }

            if (arancel.Monto < 0)
            {
                throw new ArgumentException("El monto del arancel no puede ser negativo.");
            }

            return await _repositorio.sp_arancel_actualizar(arancel);
        }
        // 4. Desactivar (Borrado lógico)
        public async Task<bool> DesactivarArancelAsync(int idArancel)
        {
            if (idArancel <= 0)
                throw new ArgumentException("El ID del arancel es inválido.");

            // Regla 1: El arancel debe existir
            var aranceles = await _repositorio.sp_arancel_listado();
            var arancel = aranceles.FirstOrDefault(a => a.IdArancel == idArancel);

            if (arancel == null)
                throw new ArgumentException("El arancel no existe en el sistema.");

            // Regla 2: No se puede desactivar un arancel que ya está inactivo
            if (!arancel.Activo)
                throw new ArgumentException("El arancel ya se encuentra desactivado.");

            return await _repositorio.sp_arancel_desactivar(idArancel);
        }
    }
}