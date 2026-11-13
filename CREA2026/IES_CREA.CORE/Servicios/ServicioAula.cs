using IES_CREA.CORE.Entidades;
using IES_CREA.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IES_CREA.CORE.Servicios
{
    public class ServicioAula
    {
        private readonly IRepositorioAulas _repositorio;

        public ServicioAula(IRepositorioAulas repositorio)
        {
            _repositorio = repositorio;
        }

        // 1. Obtener / Consultar
        public async Task<IEnumerable<Aula>> ObtenerAulasAsync(string busca)
        {
            return await _repositorio.sp_aula_consultar(busca ?? string.Empty);
        }

        // 2. Crear
        public async Task<int> CrearAulaAsync(Aula aula)
        {
            if (string.IsNullOrWhiteSpace(aula.Nombre))
                throw new ArgumentException("El nombre o número del aula es obligatorio.");

            return await _repositorio.sp_aula_insertar(aula);
        }

        // 3. Actualizar
        public async Task<Aula> ActualizarAulaAsync(Aula aula)
        {
            if (aula.IdAula <= 0)
                throw new ArgumentException("El ID del aula es inválido.");

            return await _repositorio.sp_aula_actualizar(aula);
        }

        // 4. Desactivar (Borrado lógico)
        public async Task<bool> DesactivarAulaAsync(int idAula)
        {
            if (idAula <= 0)
                throw new ArgumentException("El ID del aula es inválido.");

            // Regla 1: Buscar el aula por ID (ahora usamos una búsqueda específica)
            var aulas = await _repositorio.sp_aula_consultar(idAula.ToString());
            var aula = aulas.FirstOrDefault(a => a.IdAula == idAula);

            if (aula == null)
                throw new ArgumentException("El aula no existe en el sistema.");

            // Regla 2: Si ya está inactiva, no hacer nada
            if (!aula.Activo)
                throw new ArgumentException("El aula ya se encuentra desactivada.");

            return await _repositorio.sp_aula_desactivar(idAula);
        }
    }
}