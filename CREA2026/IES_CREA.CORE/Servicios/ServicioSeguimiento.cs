using IES_CREA.CORE.Entidades;
using IES_CREA.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IES_CREA.CORE.Servicios
{
    public class ServicioSeguimiento
    {
        private readonly IRepositorioSeguimientoPedagogico _repositorio;

        public ServicioSeguimiento(IRepositorioSeguimientoPedagogico repositorio)
        {
            _repositorio = repositorio;
        }

        // 1. Obtener los seguimientos de un alumno
        public async Task<IEnumerable<Seguimiento>> ObtenerPorAlumnoAsync(int idAlumno)
        {
            if (idAlumno <= 0) throw new ArgumentException("El ID del alumno es inválido.");
            return await _repositorio.sp_seguimientop_alumno(idAlumno);
        }

        // 2. Registrar un seguimiento (con reglas de negocio)
        public async Task<int> RegistrarSeguimientoAsync(Seguimiento seguimiento)
        {
            // Regla 1: Validar que tenga alumno, materia y docente
            if (seguimiento.IdAlumno <= 0 || seguimiento.IdMateria <= 0 || seguimiento.IdDocente <= 0)
            {
                throw new ArgumentException("El seguimiento debe estar asociado a un alumno, una materia y un docente válidos.");
            }

            // Regla 2: La fecha no puede ser futura
            var hoy = DateOnly.FromDateTime(DateTime.Today);
            if (seguimiento.Fecha > hoy)
            {
                throw new ArgumentException("La fecha del seguimiento no puede ser futura.");
            }

            // Regla 3: El tema trabajado es obligatorio
            if (string.IsNullOrWhiteSpace(seguimiento.TemaTrabajado))
            {
                throw new ArgumentException("El tema trabajado es obligatorio.");
            }

            return await _repositorio.sp_seguimientop_registrar(seguimiento);
        }

        // 3. Actualizar un seguimiento
        public async Task<Seguimiento> ActualizarSeguimientoAsync(Seguimiento seguimiento)
        {
            if (seguimiento.IdSeguimiento <= 0)
            {
                throw new ArgumentException("El ID del seguimiento es inválido.");
            }

            return await _repositorio.sp_seguimientop_actualizar(seguimiento);
        }
    }
}