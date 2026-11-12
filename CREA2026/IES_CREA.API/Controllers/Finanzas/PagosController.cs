using Microsoft.AspNetCore.Mvc;
using IES_CREA.CORE.Servicios;
using IES_CREA.CORE.Entidades;
using System;
using System.Threading.Tasks;

namespace IES_CREA.API.Controllers.Finanzas
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagosController : ControllerBase
    {
        private readonly ServicioPago _servicioPago;

        public PagosController(ServicioPago servicioPago)
        {
            _servicioPago = servicioPago;
        }

        // GET: api/Pagos/cuota/5
        [HttpGet("cuota/{idCuota}")]
        public async Task<IActionResult> ObtenerPorCuota(int idCuota)
        {
            try
            {
                var pagos = await _servicioPago.ObtenerPagosPorCuotaAsync(idCuota);
                return Ok(pagos);
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

        // POST: api/Pagos
        [HttpPost]
        public async Task<IActionResult> Registrar([FromBody] Pago pago)
        {
            try
            {
                var idGenerado = await _servicioPago.RegistrarPagoAsync(pago);
                return Ok(new { mensaje = "Pago registrado exitosamente", id = idGenerado });
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

        // PUT: api/Pagos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] Pago pago)
        {
            try
            {
                var pagoActualizado = await _servicioPago.ActualizarPagoAsync(id, pago);
                return Ok(new { mensaje = "Pago actualizado exitosamente", datos = pagoActualizado });
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