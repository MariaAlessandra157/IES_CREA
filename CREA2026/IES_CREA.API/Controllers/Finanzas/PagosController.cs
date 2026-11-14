using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using IES_CREA.CORE.Servicios;
using IES_CREA.CORE.Entidades;
using IES_CREA.API.DTOs.Finanzas;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IES_CREA.API.Controllers.Finanzas
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagosController : ControllerBase
    {
        private readonly ServicioPago _servicioPago;
        private readonly IMapper _mapper;

        public PagosController(ServicioPago servicioPago, IMapper mapper)
        {
            _servicioPago = servicioPago;
            _mapper = mapper;
        }

        // GET: api/Pagos/cuota/5
        [HttpGet("cuota/{idCuota}")]
        public async Task<IActionResult> ObtenerPorCuota(int idCuota)
        {
            try
            {
                var pagos = await _servicioPago.ObtenerPagosPorCuotaAsync(idCuota);
                var pagosDto = _mapper.Map<IEnumerable<PagoDto>>(pagos);
                return Ok(pagosDto);
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
        public async Task<IActionResult> Registrar([FromBody] PagoCrearDto dto)
        {
            try
            {
                var pago = _mapper.Map<Pago>(dto);
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

        // PUT: api/Pagos
        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] PagoActualizarDto dto)
        {
            try
            {
                var pago = _mapper.Map<Pago>(dto);
                var pagoActualizado = await _servicioPago.ActualizarPagoAsync(pago.IdPago, pago);
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