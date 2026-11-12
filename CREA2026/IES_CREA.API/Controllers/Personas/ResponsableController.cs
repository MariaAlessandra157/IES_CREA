using Microsoft.AspNetCore.Mvc;
using IES_CREA.CORE.Servicios;
using IES_CREA.CORE.Entidades;
using System;
using System.Threading.Tasks;

namespace IES_CREA.API.Controllers.Personas
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsableController : ControllerBase
    {
        private readonly ServicioResponsable _servicioResponsable;

        public ResponsableController(ServicioResponsable servicioResponsable)
        {
            _servicioResponsable = servicioResponsable;
        }

        // GET: api/Responsable/5 (por ID) o api/Responsable/0 (todos)
        [HttpGet("{idResponsable}")]
        public async Task<IActionResult> Obtener(int idResponsable)
        {
            try
            {
                var responsables = await _servicioResponsable.ObtenerResponsablesAsync(idResponsable);
                return Ok(responsables);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // POST: api/Responsable
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Responsable responsable)
        {
            try
            {
                var idGenerado = await _servicioResponsable.CrearResponsableAsync(responsable);
                return Ok(new { mensaje = "Responsable creado exitosamente", id = idGenerado });
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

        // PUT: api/Responsable/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] Responsable responsable)
        {
            try
            {
                var responsableActualizado = await _servicioResponsable.ActualizarResponsableAsync(id, responsable);
                return Ok(new { mensaje = "Responsable actualizado exitosamente", datos = responsableActualizado });
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