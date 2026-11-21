using IES_CREA.CORE.Entidades;
using IES_CREA.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IES_CREA.CORE.Servicios
{
    public class ServicioAlumno
    {
        private readonly IRepositorioAlumnos _repositorio;

        public ServicioAlumno(IRepositorioAlumnos repositorio)
        {
            _repositorio = repositorio;
        }

        // 1. Obtener todos los alumnos
        public async Task<IEnumerable<Alumno>> ObtenerTodosAsync()
        {
            return await _repositorio.sp_alumno_consultar();
        }

        // 2. Crear un alumno (con reglas de negocio)
        public async Task<int> CrearAlumnoAsync(Alumno alumno)
        {
            // Regla 1: Validar que tenga una persona asociada
            if (alumno.IdPersona <= 0)
            {
                throw new ArgumentException("El alumno debe estar asociado a una persona válida.");
            }

            // Regla 2: La fecha de ingreso no puede ser futura
            var hoy = DateTime.Today;
            if (alumno.FechaIngreso > hoy)
            {
                throw new ArgumentException("La fecha de ingreso no puede ser futura.");
            }

            // Regla 3: La fecha de egreso no puede ser futura
            if (alumno.FechaEgreso != DateTime.MinValue)
            {
                // 1. Convertimos la fecha de egreso a DateOnly
                var fechaEgresoDateOnly = DateOnly.FromDateTime(alumno.FechaEgreso);

                // 2. Aseguramos que 'hoy' también sea DateOnly. 
                // Si 'hoy' ya está declarado arriba como DateOnly, esta línea no es necesaria.
                // Pero si 'hoy' es DateTime, haz la comparación así:
                if (fechaEgresoDateOnly > DateOnly.FromDateTime(hoy))
                {
                    throw new ArgumentException("La fecha de egreso no puede ser futura.");
                }
            }

            return await _repositorio.sp_alumno_insertar(alumno);
        }

        // 3. Actualizar un alumno (según tu interfaz, recibe un string)
        public async Task<Alumno> ActualizarAlumnoAsync(Alumno alumno)
        {
            if (alumno.IdAlumno <= 0)
            {
                throw new ArgumentException("El ID del alumno es inválido.");
            }

            // Ahora el tipo de retorno coincide con lo que devuelve el repositorio
            return await _repositorio.sp_alumno_actualizar(alumno);
        }

        public async Task ActualizarAlumnoAsync(string busca)
        {
            throw new NotImplementedException();
        }
    }
}