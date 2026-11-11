using Microsoft.AspNetCore.Mvc;
using IES_CREA.CORE.Servicios;
using IES_CREA.CORE.Entidades; // <-- ESTE ES EL QUE FALTABA
using System;
using System.Threading.Tasks;

namespace IES_CREA.API.Controllers.Academico
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguimientoPedagogicoController : ControllerBase
    {
        private readonly ServicioSeguimiento _servicioSeguimiento;

        public SeguimientoPedagogicoController(ServicioSeguimiento servicioSeguimiento)
        {
            _servicioSeguimiento = servicioSeguimiento;
        }

        // GET: api/SeguimientoPedagogico/alumno/5
        [HttpGet("alumno/{idAlumno}")]
        public async Task<IActionResult> ObtenerPorAlumno(int idAlumno)
        {
            try
            {
                var seguimientos = await _servicioSeguimiento.ObtenerPorAlumnoAsync(idAlumno);
                return Ok(seguimientos);
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

        // POST: api/SeguimientoPedagogico
        [HttpPost]
        public async Task<IActionResult> Registrar([FromBody] Seguimiento seguimiento)
        {
            try
            {
                var idGenerado = await _servicioSeguimiento.RegistrarSeguimientoAsync(seguimiento);
                return Ok(new { mensaje = "Seguimiento registrado exitosamente", id = idGenerado });
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

        // PUT: api/SeguimientoPedagogico/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] Seguimiento seguimiento)
        {
            try
            {
                seguimiento.IdSeguimiento = id;
                var seguimientoActualizado = await _servicioSeguimiento.ActualizarSeguimientoAsync(seguimiento);
                return Ok(new { mensaje = "Seguimiento actualizado exitosamente", datos = seguimientoActualizado });
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