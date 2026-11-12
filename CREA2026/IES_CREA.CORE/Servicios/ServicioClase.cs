using IES_CREA.CORE.Entidades;
using IES_CREA.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IES_CREA.CORE.Servicios
{
    public class ServicioClase
    {
        private readonly IRepositorioClases _repositorio;

        public ServicioClase(IRepositorioClases repositorio)
        {
            _repositorio = repositorio;
        }

        // 1. Consultar (por ID o traer todas si el ID es 0)
        public async Task<IEnumerable<Clase>> ObtenerClasesAsync(int idClase)
        {
            return await _repositorio.sp_clase_consultar(idClase);
        }

        // 2. Crear (con reglas de negocio)
        public async Task<int> CrearClaseAsync(Clase clase)
        {
            // Regla de negocio 1: La fecha no puede ser en el pasado
            // Como Fecha es DateOnly, usamos DateOnly.FromDateTime para comparar
            var hoy = DateOnly.FromDateTime(DateTime.Today);

            if (clase.Fecha < hoy)
            {
                throw new ArgumentException("La fecha de la clase no puede ser en el pasado.");
            }

            // Regla de negocio 2: Validar que tenga asignado un docente y una materia
            if (clase.IdDocente <= 0 || clase.IdMateria <= 0)
            {
                throw new ArgumentException("La clase debe tener un docente y una materia asignados.");
            }

            // Regla de negocio 3 (Opcional): Validar que la hora de fin sea mayor a la de inicio
            if (clase.HoraFinal <= clase.HoraInicio)
            {
                throw new ArgumentException("La hora de finalización debe ser posterior a la hora de inicio.");
            }

            return await _repositorio.sp_clase_crear(clase);
        }

        // 3. Actualizar
        public async Task<Clase> ActualizarClaseAsync(Clase clase)
        {
            if (clase.IdClase <= 0)
            {
                throw new ArgumentException("El ID de la clase es inválido.");
            }

            return await _repositorio.sp_clase_actualizar(clase);
        }
    }
}