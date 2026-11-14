using IES_CREA.CORE.Entidades;
using IES_CREA.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IES_CREA.CORE.Servicios
{
    public class ServicioCurso
    {
        private readonly IRepositorioCursos _repositorio;

        public ServicioCurso(IRepositorioCursos repositorio)
        {
            _repositorio = repositorio;
        }

        // 1. Obtener todos
        public async Task<IEnumerable<Curso>> ObtenerCursosAsync()
        {
            return await _repositorio.sp_curso_consultar();
        }

        // 2. Crear (con validaciones de negocio)
        public async Task<int> CrearCursoAsync(Curso curso)
        {
            // Regla de negocio de ejemplo: El nombre del curso no puede estar vacío
            if (string.IsNullOrWhiteSpace(curso.Nombre))
            {
                throw new ArgumentException("El nombre del curso es obligatorio.");
            }

            // Aquí podrías validar que tenga un NivelEducativo asignado, por ejemplo:
            // if (curso.IdNivelEducativo <= 0) 
            //     throw new ArgumentException("El curso debe tener un nivel educativo asignado.");

            return await _repositorio.sp_curso_insertar(curso);
        }

        // 3. Actualizar
        public async Task<Curso> ActualizarCursoAsync(Curso curso)
        {
            if (curso.IdCurso <= 0) // Ajusta "IdCurso" según tu entidad
            {
                throw new ArgumentException("El ID del curso es inválido.");
            }

            return await _repositorio.sp_curso_actualizar(curso);
        }
    }
}