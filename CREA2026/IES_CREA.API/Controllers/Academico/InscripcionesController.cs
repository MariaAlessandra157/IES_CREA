using Microsoft.AspNetCore.Mvc;
using IES_CREA.CORE.Servicios;
using IES_CREA.CORE.Entidades;
using System;
using System.Threading.Tasks;

namespace IES_CREA.API.Controllers.Academico
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscripcionesController : ControllerBase
    {
        private readonly ServicioInscripcion _servicioInscripcion;

        public InscripcionesController(ServicioInscripcion servicioInscripcion)
        {
            _servicioInscripcion = servicioInscripcion;
        }

        // GET: api/Inscripciones
        [HttpGet]
        public async Task<IActionResult> ObtenerTodas()
        {
            try
            {
                var inscripciones = await _servicioInscripcion.ObtenerTodasAsync();
                return Ok(inscripciones);
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
                return Ok(inscripciones);
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
        public async Task<IActionResult> Crear([FromBody] Inscripcion inscripcion)
        {
            try
            {
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

        // PUT: api/Inscripciones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] Inscripcion inscripcion)
        {
            try
            {
                inscripcion.IdInscripcion = id; // Ajusta según tu entidad
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
    }
}