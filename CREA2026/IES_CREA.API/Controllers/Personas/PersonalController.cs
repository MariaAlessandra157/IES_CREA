using Microsoft.AspNetCore.Mvc;
using IES_CREA.CORE.Servicios;
using IES_CREA.CORE.Entidades;
using System;
using System.Threading.Tasks;

namespace IES_CREA.API.Controllers.Personas
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalController : ControllerBase
    {
        private readonly ServicioPersonal _servicioPersonal;

        public PersonalController(ServicioPersonal servicioPersonal)
        {
            _servicioPersonal = servicioPersonal;
        }

        // GET: api/Personal/5 (por ID) o api/Personal/0 (todos)
        [HttpGet("{idPersonal}")]
        public async Task<IActionResult> Obtener(int idPersonal)
        {
            try
            {
                var personal = await _servicioPersonal.ObtenerPersonalAsync(idPersonal);
                return Ok(personal);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // POST: api/Personal
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Personal personal)
        {
            try
            {
                var idGenerado = await _servicioPersonal.CrearPersonalAsync(personal);
                return Ok(new { mensaje = "Personal creado exitosamente", id = idGenerado });
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

        // PUT: api/Personal/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] Personal personal)
        {
            try
            {
                var personalActualizado = await _servicioPersonal.ActualizarPersonalAsync(id, personal);
                return Ok(new { mensaje = "Personal actualizado exitosamente", datos = personalActualizado });
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