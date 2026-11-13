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
    public class CuotasController : ControllerBase
    {
        private readonly ServicioCuota _servicioCuota;
        private readonly IMapper _mapper;

        public CuotasController(ServicioCuota servicioCuota, IMapper mapper)
        {
            _servicioCuota = servicioCuota;
            _mapper = mapper;
        }

        // GET: api/Cuotas/inscripcion/5
        [HttpGet("inscripcion/{idInscripcion}")]
        public async Task<IActionResult> ObtenerPorInscripcion(int idInscripcion)
        {
            try
            {
                var cuotas = await _servicioCuota.ObtenerPorInscripcionAsync(idInscripcion);
                var cuotasDto = _mapper.Map<IEnumerable<CuotaDto>>(cuotas);
                return Ok(cuotasDto);
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
        public async Task<IActionResult> Generar([FromBody] CuotaCrearDto dto)
        {
            try
            {
                var cuota = _mapper.Map<Cuota>(dto);
                cuota.Estado = false; // Por defecto, pendiente de pago

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

        // PUT: api/Cuotas
        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] CuotaActualizarDto dto)
        {
            try
            {
                var cuota = _mapper.Map<Cuota>(dto);
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
        // DELETE: api/Cuotas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Desactivar(int id)
        {
            try
            {
                var resultado = await _servicioCuota.DesactivarCuotaAsync(id);

                if (resultado)
                {
                    return Ok(new { mensaje = "Cuota desactivada exitosamente (borrado lógico)." });
                }

                return NotFound("Cuota no encontrada.");
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