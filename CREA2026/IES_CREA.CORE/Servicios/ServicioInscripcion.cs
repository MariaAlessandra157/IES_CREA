using IES_CREA.CORE.Entidades;
using IES_CREA.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IES_CREA.CORE.Servicios
{
    public class ServicioInscripcion
    {
        private readonly IRepositorioInscripciones _repositorio;

        public ServicioInscripcion(IRepositorioInscripciones repositorio)
        {
            _repositorio = repositorio;
        }

        // 1. Obtener todas las inscripciones
        public async Task<IEnumerable<Inscripcion>> ObtenerTodasAsync()
        {
            return await _repositorio.sp_inscripcion_consultar();
        }

        // 2. Obtener las inscripciones de un alumno específico
        public async Task<IEnumerable<Inscripcion>> ObtenerPorAlumnoAsync(int idAlumno)
        {
            if (idAlumno <= 0) throw new ArgumentException("El ID del alumno es inválido.");
            return await _repositorio.sp_inscripciones_alumno(idAlumno);
        }

        // 3. Crear una inscripción (con reglas de negocio)
        public async Task<int> CrearInscripcionAsync(Inscripcion inscripcion)
        {
            // Regla 1: Validar que tenga un alumno asignado
            if (inscripcion.IdAlumno <= 0)
            {
                throw new ArgumentException("La inscripción debe tener un alumno válido.");
            }

            // Regla 2: La fecha de inicio no puede ser mayor que la fecha de fin
            if (inscripcion.FechaInicio > inscripcion.FechaFin)
            {
                throw new ArgumentException("La fecha de inicio no puede ser posterior a la fecha de fin.");
            }

            // Regla 3: No se puede inscribir con una fecha de inicio en el pasado muy lejano (opcional)
            // var hoy = DateOnly.FromDateTime(DateTime.Today);
            // if (inscripcion.FechaInicio < hoy) 
            //     throw new ArgumentException("La fecha de inicio no puede ser en el pasado.");

            return await _repositorio.sp_inscripcion_crear(inscripcion);
        }

        // 4. Actualizar
        public async Task<Inscripcion> ActualizarInscripcionAsync(Inscripcion inscripcion)
        {
            if (inscripcion.IdInscripcion <= 0) // Ajusta según tu entidad
            {
                throw new ArgumentException("El ID de la inscripción es inválido.");
            }

            return await _repositorio.sp_inscripcion_actualizar(inscripcion);
        }
    }
}