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

        // 1. Obtener todas las personas
        public async Task<IEnumerable<Persona>> ObtenerTodosAsync()
        {
            return await _repositorio.sp_persona_obtener();
        }

        // 2. Obtener por ID
        public async Task<Persona> ObtenerPorIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor a 0");

            return await _repositorio.ObtenerPersonaPorId(id);
        }

        // 3. Buscar por DNI, nombre o apellido
        public async Task<IEnumerable<Persona>> BuscarAsync(string busca)
        {
            return await _repositorio.sp_persona_buscar(busca ?? string.Empty);
        }

        // 4. Crear una persona
        public async Task<Persona> CrearPersonaAsync(Persona persona)
        {
            // Regla de negocio: El DNI es obligatorio
            if (string.IsNullOrWhiteSpace(persona.Dni))
                throw new ArgumentException("El DNI es obligatorio.");

            var idGenerado = await _repositorio.sp_persona_insertar(persona);
            if (idGenerado > 0) persona.IdPersona = idGenerado;

            return persona;
        }

        // 5. Actualizar una persona
        public async Task<Persona> ActualizarPersonaAsync(Persona persona)
        {
            if (persona.IdPersona <= 0)
                throw new ArgumentException("El ID de la persona es inválido.");

            return await _repositorio.sp_persona_actualizar(persona);
        }
    }
}