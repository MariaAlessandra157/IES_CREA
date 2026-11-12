using Microsoft.AspNetCore.Mvc;
using IES_CREA.CORE.Servicios;
using IES_CREA.CORE.Entidades;
using System;
using System.Threading.Tasks;

namespace IES_CREA.API.Controllers.Finanzas
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArancelesController : ControllerBase
    {
        private readonly ServicioArancel _servicioArancel;

        public ArancelesController(ServicioArancel servicioArancel)
        {
            _servicioArancel = servicioArancel;
        }

        // GET: api/Aranceles
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            try
            {
                var aranceles = await _servicioArancel.ObtenerArancelesAsync();
                return Ok(aranceles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // POST: api/Aranceles
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Arancel arancel)
        {
            try
            {
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

        // PUT: api/Aranceles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] Arancel arancel)
        {
            try
            {
                arancel.IdArancel = id;
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
    }
}