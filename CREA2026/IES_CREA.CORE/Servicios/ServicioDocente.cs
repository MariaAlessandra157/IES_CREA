using IES_CREA.CORE.Entidades;
using IES_CREA.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IES_CREA.CORE.Servicios
{
    public class ServicioDocente
    {
        private readonly IRepositorioDocentes _repositorio;

        public ServicioDocente(IRepositorioDocentes repositorio)
        {
            _repositorio = repositorio;
        }

        // 1. Obtener todos los docentes
        public async Task<IEnumerable<Docente>> ObtenerTodosAsync()
        {
            return await _repositorio.sp_docente_consultar();
        }

        // 2. Crear un docente (con reglas de negocio)
        public async Task<int> CrearDocenteAsync(Docente docente)
        {
            // Regla 1: Validar que tenga una persona asociada
            if (docente.IdPersona <= 0)
            {
                throw new ArgumentException("El docente debe estar asociado a una persona válida.");
            }

            // Regla 2: La especialidad es obligatoria
            if (string.IsNullOrWhiteSpace(docente.Especialidad))
            {
                throw new ArgumentException("La especialidad del docente es obligatoria.");
            }

            // Regla 3: La fecha de alta no puede ser futura
            var hoy = DateOnly.FromDateTime(DateTime.Today);
            if (docente.FechaAlta > hoy)
            {
                throw new ArgumentException("La fecha de alta no puede ser futura.");
            }

            return await _repositorio.sp_docente_insertar(docente);
        }

        // 3. Actualizar un docente
        public async Task<Docente> ActualizarDocenteAsync(Docente docente)
        {
            if (docente.IdDocente <= 0)
            {
                throw new ArgumentException("El ID del docente es inválido.");
            }

            return await _repositorio.sp_docente_actualizar(docente);
        }
    }
}