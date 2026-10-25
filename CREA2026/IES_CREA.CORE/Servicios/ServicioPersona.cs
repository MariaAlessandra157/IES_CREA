using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IES_CREA.CORE.Entidades;
using IES_CREA.CORE.Interfaces;

namespace IES_CREA.CORE.Servicios
{
    public class ServicioPersona
    {
        private readonly IRepositorioPersona _repositorio;

        public ServicioPersona(IRepositorioPersona repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<IEnumerable<Persona>> ObtenerPersonaPorId(int p_id)
        {
            // NOTA: En lugar de traer TODOS y filtrar en memoria (Where), 
            // es mejor crear un SP que busque por ID, o usar el de buscar si aplica.
            // Si no tienes uno por ID, aquí está el filtro en memoria:
            var personas = await _repositorio.sp_persona_obtener();
            return personas.Where(p => p.IdPersona == p_id);
        }

        public async Task<Persona> GetByIdAsync(int p_id)
        {
            if (p_id <= 0)
                throw new ArgumentException("El ID debe ser mayor a 0");

            // Idealmente deberías tener un método en tu repositorio: _repositorio.sp_persona_obtener_por_id(p_id)
            var personas = await _repositorio.sp_persona_obtener();
            return personas.FirstOrDefault(p => p.IdPersona == p_id);
        }
    }
}