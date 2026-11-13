using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using IES_CREA.CORE.Servicios;
using IES_CREA.CORE.Entidades;
using IES_CREA.API.DTOs.Persona;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IES_CREA.API.Controllers.Personas
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly ServicioPersona _servicioPersona;
        private readonly IMapper _mapper;

        public PersonasController(ServicioPersona servicioPersona, IMapper mapper)
        {
            _servicioPersona = servicioPersona;
            _mapper = mapper;
        }

        // GET: api/Personas
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            try
            {
                var personas = await _servicioPersona.ObtenerTodosAsync();
                var personasDto = _mapper.Map<IEnumerable<PersonaDto>>(personas);
                return Ok(personasDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // GET: api/Personas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            try
            {
                var persona = await _servicioPersona.ObtenerPorIdAsync(id);
                if (persona == null) return NotFound("Persona no encontrada");

                var personaDto = _mapper.Map<PersonaDto>(persona);
                return Ok(personaDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // GET: api/Personas/buscar?termino=Juan
        [HttpGet("buscar")]
        public async Task<IActionResult> Buscar([FromQuery] string termino)
        {
            try
            {
                var personas = await _servicioPersona.BuscarAsync(termino);
                var personasDto = _mapper.Map<IEnumerable<PersonaDto>>(personas);
                return Ok(personasDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // POST: api/Personas
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] PersonaCrearDto dto)
        {
            try
            {
                var persona = _mapper.Map<Persona>(dto);
                persona.Activo = true;
                persona.FechaAlta = DateOnly.FromDateTime(DateTime.Today);

                var personaCreada = await _servicioPersona.CrearPersonaAsync(persona);
                var personaDto = _mapper.Map<PersonaDto>(personaCreada);

                return Ok(new { mensaje = "Persona creada exitosamente", datos = personaDto });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // PUT: api/Personas
        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] PersonaActualizarDto dto)
        {
            try
            {
                var persona = _mapper.Map<Persona>(dto);
                var personaActualizada = await _servicioPersona.ActualizarPersonaAsync(persona);
                var personaDto = _mapper.Map<PersonaDto>(personaActualizada);

                return Ok(new { mensaje = "Persona actualizada exitosamente", datos = personaDto });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
    }
}