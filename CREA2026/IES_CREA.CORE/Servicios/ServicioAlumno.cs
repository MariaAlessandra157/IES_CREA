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
            var hoy = DateOnly.FromDateTime(DateTime.Today);
            if (alumno.FechaIngreso > hoy)
            {
                throw new ArgumentException("La fecha de ingreso no puede ser futura.");
            }

            // Regla 3: La fecha de egreso no puede ser futura
            if (alumno.FechaEgreso > hoy && alumno.FechaEgreso != DateOnly.MinValue)
            {
                throw new ArgumentException("La fecha de egreso no puede ser futura.");
            }

            return await _repositorio.sp_alumno_insertar(alumno);
        }

        // 3. Actualizar un alumno (según tu interfaz, recibe un string)
        public async Task<IEnumerable<Alumno>> ActualizarAlumnoAsync(string busca)
        {
            return await _repositorio.sp_alumno_actualizar(busca);
        }
    }
}