using IES_CREA.CORE.Entidades;
using IES_CREA.CORE.Interfaces;
using System;
using System.Collections.Generic;
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

        // 1. Obtener / Consultar (usando el nombre exacto de tu interfaz)
        public async Task<IEnumerable<Aula>> ObtenerAulasAsync(string busca)
        {
            // Si no hay término de búsqueda, enviamos un string vacío o null
            return await _repositorio.sp_aula_consultar(busca ?? string.Empty);
        }

        // 2. Crear
        public async Task<int> CrearAulaAsync(Aula aula)
        {
            // Regla de negocio de ejemplo: El nombre/número del aula no puede estar vacío
            if (string.IsNullOrWhiteSpace(aula.Nombre)) // Ajusta "Nombre" según tu entidad Aula
            {
                throw new ArgumentException("El nombre o número del aula es obligatorio.");
            }

            return await _repositorio.sp_aula_insertar(aula);
        }

        // 3. Actualizar
        public async Task<Aula> ActualizarAulaAsync(Aula aula)
        {
            if (aula.IdAula <= 0) // Ajusta "IdAula" según tu entidad
            {
                throw new ArgumentException("El ID del aula es inválido.");
            }

            return await _repositorio.sp_aula_actualizar(aula);
        }
    }
}