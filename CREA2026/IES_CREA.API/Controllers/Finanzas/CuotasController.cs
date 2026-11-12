using Microsoft.AspNetCore.Mvc;
using IES_CREA.CORE.Servicios;
using IES_CREA.CORE.Entidades;
using System;
using System.Threading.Tasks;

namespace IES_CREA.API.Controllers.Finanzas
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuotasController : ControllerBase
    {
        private readonly ServicioCuota _servicioCuota;

        public CuotasController(ServicioCuota servicioCuota)
        {
            _servicioCuota = servicioCuota;
        }

        // GET: api/Cuotas/inscripcion/5
        [HttpGet("inscripcion/{idInscripcion}")]
        public async Task<IActionResult> ObtenerPorInscripcion(int idInscripcion)
        {
            try
            {
                var cuotas = await _servicioCuota.ObtenerPorInscripcionAsync(idInscripcion);
                return Ok(cuotas);
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

        // POST: api/Cuotas
        [HttpPost]
        public async Task<IActionResult> Generar([FromBody] Cuota cuota)
        {
            try
            {
                var idGenerado = await _servicioCuota.GenerarCuotaAsync(cuota);
                return Ok(new { mensaje = "Cuota generada exitosamente", id = idGenerado });
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

        // PUT: api/Cuotas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] Cuota cuota)
        {
            try
            {
                cuota.IdCuotas = id;
                var cuotaActualizada = await _servicioCuota.ActualizarCuotaAsync(cuota);
                return Ok(new { mensaje = "Cuota actualizada exitosamente", datos = cuotaActualizada });
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