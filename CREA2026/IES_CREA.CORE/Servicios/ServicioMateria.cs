using IES_CREA.CORE.Entidades;
using IES_CREA.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IES_CREA.CORE.Servicios
{
    public class ServicioMateria
    {
        private readonly IRepositorioMaterias _repositorio;

        public ServicioMateria(IRepositorioMaterias repositorio)
        {
            _repositorio = repositorio;
        }

        // 1. Obtener todas
        public async Task<IEnumerable<Materia>> ObtenerTodasAsync()
        {
            return await _repositorio.sp_materia_consultar();
        }

        // 2. Crear (con validaciones de negocio)
        public async Task<int> CrearMateriaAsync(Materia materia)
        {
            // Ejemplo de regla de negocio: El nombre no puede estar vacío
            if (string.IsNullOrWhiteSpace(materia.Nombre))
            {
                throw new ArgumentException("El nombre de la materia es obligatorio.");
            }

            // Aquí podrías agregar más reglas, ej: verificar si ya existe una materia con ese nombre.

            return await _repositorio.sp_materia_insertar(materia);
        }

        // 3. Actualizar
        public async Task<Materia> ActualizarMateriaAsync(Materia materia)
        {
            if (materia.IdMateria <= 0)
            {
                throw new ArgumentException("El ID de la materia es inválido.");
            }

            return await _repositorio.sp_materia_actualizar(materia);
        }
        // 4. Desactivar (Borrado lógico)
        public async Task<bool> DesactivarMateriaAsync(int idMateria)
        {
            if (idMateria <= 0)
                throw new ArgumentException("El ID de la materia es inválido.");

            // Regla 1: La materia debe existir
            var materias = await _repositorio.sp_materia_consultar();
            var materia = materias.FirstOrDefault(m => m.IdMateria == idMateria);

            if (materia == null)
                throw new ArgumentException("La materia no existe en el sistema.");

            // Regla 2: No se puede desactivar una materia que ya está inactiva
            if (!materia.Activo)
                throw new ArgumentException("La materia ya se encuentra desactivada.");

            return await _repositorio.sp_materia_desactivar(idMateria);
        }
    }
}