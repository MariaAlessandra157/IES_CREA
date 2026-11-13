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
    public class ArancelesController : ControllerBase
    {
        private readonly ServicioArancel _servicioArancel;
        private readonly IMapper _mapper;

        public ArancelesController(ServicioArancel servicioArancel, IMapper mapper)
        {
            _servicioArancel = servicioArancel;
            _mapper = mapper;
        }

        // GET: api/Aranceles
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            try
            {
                var aranceles = await _servicioArancel.ObtenerArancelesAsync();
                var arancelesDto = _mapper.Map<IEnumerable<ArancelDto>>(aranceles);
                return Ok(arancelesDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // POST: api/Aranceles
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] ArancelCrearDto dto)
        {
            try
            {
                var arancel = _mapper.Map<Arancel>(dto);
                arancel.Activo = true; // Por defecto activo

                var idGenerado = await _servicioArancel.CrearArancelAsync(arancel);
                return Ok(new { mensaje = "Arancel creado exitosamente", id = idGenerado });
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

        // PUT: api/Aranceles
        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] ArancelActualizarDto dto)
        {
            try
            {
                var arancel = _mapper.Map<Arancel>(dto);
                var arancelActualizado = await _servicioArancel.ActualizarArancelAsync(arancel);
                return Ok(new { mensaje = "Arancel actualizado exitosamente", datos = arancelActualizado });
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
        // DELETE: api/Aranceles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Desactivar(int id)
        {
            try
            {
                var resultado = await _servicioArancel.DesactivarArancelAsync(id);

                if (resultado)
                {
                    return Ok(new { mensaje = "Arancel desactivado exitosamente (borrado lógico)." });
                }

                return NotFound("Arancel no encontrado.");
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