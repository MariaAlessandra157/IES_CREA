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
    public class DocentesController : ControllerBase
    {
        private readonly ServicioDocente _servicioDocente;
        private readonly IMapper _mapper;

        public DocentesController(ServicioDocente servicioDocente, IMapper mapper)
        {
            _servicioDocente = servicioDocente;
            _mapper = mapper;
        }

        // GET: api/Docentes
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            try
            {
                var docentes = await _servicioDocente.ObtenerTodosAsync();
                var docentesDto = _mapper.Map<IEnumerable<DocenteDto>>(docentes);
                return Ok(docentesDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // POST: api/Docentes
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] DocenteCrearDto dto)
        {
            try
            {
                var docente = _mapper.Map<Docente>(dto);
                docente.Activo = true; // Por defecto activo

                var idGenerado = await _servicioDocente.CrearDocenteAsync(docente);
                return Ok(new { mensaje = "Docente creado exitosamente", id = idGenerado });
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

        // PUT: api/Docentes
        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] DocenteActualizarDto dto)
        {
            try
            {
                var docente = _mapper.Map<Docente>(dto);
                var docenteActualizado = await _servicioDocente.ActualizarDocenteAsync(docente);
                return Ok(new { mensaje = "Docente actualizado exitosamente", datos = docenteActualizado });
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