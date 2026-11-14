using IES_CREA.CORE.Entidades;
using IES_CREA.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IES_CREA.CORE.Servicios
{
    public class ServicioTrayectoria
    {
        private readonly IRepositorioTrayectoriaEducativa _repositorio;

        public ServicioTrayectoria(IRepositorioTrayectoriaEducativa repositorio)
        {
            _repositorio = repositorio;
        }

        // 1. Obtener la trayectoria de un alumno
        public async Task<IEnumerable<Trayectoria>> ObtenerPorAlumnoAsync(int idAlumno)
        {
            if (idAlumno <= 0) throw new ArgumentException("El ID del alumno es inválido.");
            return await _repositorio.sp_trayectoria_alumno(idAlumno);
        }

        // 2. Registrar una trayectoria (con reglas de negocio)
        public async Task<int> RegistrarTrayectoriaAsync(Trayectoria trayectoria)
        {
            // Regla 1: Validar que tenga alumno, institución y curso
            if (trayectoria.IdAlumno <= 0 || trayectoria.IdInstitucion <= 0 || trayectoria.IdCurso <= 0)
            {
                throw new ArgumentException("La trayectoria debe estar asociada a un alumno, una institución y un curso válidos.");
            }

            // Regla 2: La fecha desde no puede ser futura
            var hoy = DateOnly.FromDateTime(DateTime.Today);
            if (trayectoria.FechaDesde > hoy)
            {
                throw new ArgumentException("La fecha 'desde' no puede ser futura.");
            }

            // Regla 3: La fecha hasta debe ser mayor o igual que la fecha desde
            if (trayectoria.FechaHasta < trayectoria.FechaDesde)
            {
                throw new ArgumentException("La fecha 'hasta' debe ser mayor o igual que la fecha 'desde'.");
            }

            // Regla 4: El ciclo lectivo debe tener 4 caracteres (ej: "2026")
            if (string.IsNullOrWhiteSpace(trayectoria.Ciclolectivo) || trayectoria.Ciclolectivo.Length != 4)
            {
                throw new ArgumentException("El ciclo lectivo debe tener 4 caracteres (ej: 2026).");
            }

            return await _repositorio.sp_trayectoria_registrar(trayectoria);
        }

        // 3. Actualizar una trayectoria
        public async Task<Trayectoria> ActualizarTrayectoriaAsync(Trayectoria trayectoria)
        {
            if (trayectoria.IdTrayectoria <= 0)
            {
                throw new ArgumentException("El ID de la trayectoria es inválido.");
            }

            return await _repositorio.sp_trayectoria_actualizar(trayectoria);
        }
    }
}