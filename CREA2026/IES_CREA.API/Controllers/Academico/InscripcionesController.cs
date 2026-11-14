using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using IES_CREA.CORE.Servicios;
using IES_CREA.CORE.Entidades;
using IES_CREA.API.DTOs.Academico;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IES_CREA.API.Controllers.Academico
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscripcionesController : ControllerBase
    {
        private readonly ServicioInscripcion _servicioInscripcion;
        private readonly IMapper _mapper;

        public InscripcionesController(ServicioInscripcion servicioInscripcion, IMapper mapper)
        {
            _servicioInscripcion = servicioInscripcion;
            _mapper = mapper;
        }

        // GET: api/Inscripciones
        [HttpGet]
        public async Task<IActionResult> ObtenerTodas()
        {
            try
            {
                var inscripciones = await _servicioInscripcion.ObtenerTodasAsync();
                var inscripcionesDto = _mapper.Map<IEnumerable<InscripcionDto>>(inscripciones);
                return Ok(inscripcionesDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // GET: api/Inscripciones/alumno/5
        [HttpGet("alumno/{idAlumno}")]
        public async Task<IActionResult> ObtenerPorAlumno(int idAlumno)
        {
            try
            {
                var inscripciones = await _servicioInscripcion.ObtenerPorAlumnoAsync(idAlumno);
                var inscripcionesDto = _mapper.Map<IEnumerable<InscripcionDto>>(inscripciones);
                return Ok(inscripcionesDto);
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

        // POST: api/Inscripciones
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] InscripcionCrearDto dto)
        {
            try
            {
                var inscripcion = _mapper.Map<Inscripcion>(dto);
                inscripcion.Estado = true; // Por defecto activa

                var idGenerado = await _servicioInscripcion.CrearInscripcionAsync(inscripcion);
                return Ok(new { mensaje = "Inscripción creada exitosamente", id = idGenerado });
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

        // PUT: api/Inscripciones
        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] InscripcionActualizarDto dto)
        {
            try
            {
                var inscripcion = _mapper.Map<Inscripcion>(dto);
                var inscripcionActualizada = await _servicioInscripcion.ActualizarInscripcionAsync(inscripcion);
                return Ok(new { mensaje = "Inscripción actualizada exitosamente", datos = inscripcionActualizada });
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
        // DELETE: api/Inscripciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Desactivar(int id)
        {
            try
            {
                var resultado = await _servicioInscripcion.DesactivarInscripcionAsync(id);

                if (resultado)
                {
                    return Ok(new { mensaje = "Inscripción desactivada exitosamente (borrado lógico)." });
                }

                return NotFound("Inscripción no encontrada.");
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