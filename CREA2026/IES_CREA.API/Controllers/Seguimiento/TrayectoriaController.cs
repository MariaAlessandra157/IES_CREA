using Microsoft.AspNetCore.Mvc;
using IES_CREA.CORE.Servicios;
using IES_CREA.CORE.Entidades;
using System;
using System.Threading.Tasks;

namespace IES_CREA.API.Controllers.Academico
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrayectoriaController : ControllerBase
    {
        private readonly ServicioTrayectoria _servicioTrayectoria;

        public TrayectoriaController(ServicioTrayectoria servicioTrayectoria)
        {
            _servicioTrayectoria = servicioTrayectoria;
        }

        // GET: api/Trayectoria/alumno/5
        [HttpGet("alumno/{idAlumno}")]
        public async Task<IActionResult> ObtenerPorAlumno(int idAlumno)
        {
            try
            {
                var trayectorias = await _servicioTrayectoria.ObtenerPorAlumnoAsync(idAlumno);
                return Ok(trayectorias);
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

        // POST: api/Trayectoria
        [HttpPost]
        public async Task<IActionResult> Registrar([FromBody] Trayectoria trayectoria)
        {
            try
            {
                var idGenerado = await _servicioTrayectoria.RegistrarTrayectoriaAsync(trayectoria);
                return Ok(new { mensaje = "Trayectoria registrada exitosamente", id = idGenerado });
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

        // PUT: api/Trayectoria/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] Trayectoria trayectoria)
        {
            try
            {
                trayectoria.IdTrayectoria = id;
                var trayectoriaActualizada = await _servicioTrayectoria.ActualizarTrayectoriaAsync(trayectoria);
                return Ok(new { mensaje = "Trayectoria actualizada exitosamente", datos = trayectoriaActualizada });
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