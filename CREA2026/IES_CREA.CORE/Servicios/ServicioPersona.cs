using IES_CREA.CORE.Entidades;
using IES_CREA.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IES_CREA.CORE.Servicios
{
    public class ServicioPersona
    {
        private readonly IRepositorioPersona _repositorio;

        public ServicioPersona(IRepositorioPersona repositorio)
        {
            _repositorio = repositorio;
        }

        // 1. Obtener todos (útil para un futuro GET general)
        public async Task<IEnumerable<Persona>> ObtenerTodosAsync()
        {
            // NOTA: Necesitarás crear este método en tu IRepositorioPersona y RepositorioPersona
            // return await _repositorio.ObtenerTodosAsync();
            throw new NotImplementedException("Falta implementar en el repositorio");
        }

        // 2. Obtener por ID (Corregido: devuelve una sola Persona)
        public async Task<Persona> ObtenerPorIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor a 0");

            return await _repositorio.ObtenerPersonaPorId(id); // Asumo que tu repositorio devuelve un Task<Persona>
        }

        // 3. CREAR ALUMNO (El que usaremos en el Controlador)
        public async Task<Persona> CrearAlumnoAsync(Persona persona)
        {
            var idGenerado = await _repositorio.sp_persona_insertar(persona);
            if (idGenerado > 0) persona.IdPersona = idGenerado;
            return persona;
        }
    }
}