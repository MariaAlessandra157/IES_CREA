using IES_CREA.CORE.Entidades;
using IES_CREA.CORE.Interfaces;
using IES_CREA.CORE.Entidades;
using IES_CREA.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IES_CREA.CORE.Servicios
{
    public class ServicioPersonal
    {
        private readonly IRepositorioPersonal _repositorio;

        public ServicioPersonal(IRepositorioPersonal repositorio)
        {
            _repositorio = repositorio;
        }

        // 1. Obtener personal (por ID o todos)
        public async Task<IEnumerable<Personal>> ObtenerPersonalAsync(int idPersonal)
        {
            // Si el ID es 0 o negativo, asumimos que quiere traer todos
            return await _repositorio.sp_personal_consultar(idPersonal);
        }

        // 2. Crear Personal (con reglas de negocio)
        public async Task<int> CrearPersonalAsync(Personal personal)
        {
            // Regla 1: Debe tener una persona y un cargo asignados
            if (personal.IdPersona <= 0)
            {
                throw new ArgumentException("El personal debe estar asociado a una persona válida.");
            }

            if (personal.IdCargo <= 0)
            {
                throw new ArgumentException("El personal debe tener un cargo asignado.");
            }

            // Regla 2: La fecha de ingreso no puede ser en el futuro
            var hoy = DateOnly.FromDateTime(DateTime.Today);
            if (personal.FechaIngreso > hoy)
            {
                throw new ArgumentException("La fecha de ingreso no puede ser futura.");
            }

            return await _repositorio.sp_personal_insertar(personal);
        }

        // 3. Actualizar Personal
        public async Task<Personal> ActualizarPersonalAsync(int idPersonal, Personal personal)
        {
            if (idPersonal <= 0)
            {
                throw new ArgumentException("El ID del personal es inválido.");
            }

            // Asignamos el ID al objeto (por si el frontend no lo envió)
            personal.IdPersonal = idPersonal;

            // AHORA LE PASAMOS EL OBJETO COMPLETO, NO EL ID
            return await _repositorio.sp_personal_actualizar(personal);
        }
    }
}