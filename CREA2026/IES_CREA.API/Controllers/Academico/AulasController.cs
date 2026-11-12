using Microsoft.AspNetCore.Mvc;
using IES_CREA.CORE.Servicios;
using IES_CREA.CORE.Entidades;
using System;
using System.Threading.Tasks;

namespace IES_CREA.API.Controllers.Academico
{
    [Route("api/[controller]")]
    [ApiController]
    public class AulasController : ControllerBase
    {
        private readonly ServicioAula _servicioAula;

        public AulasController(ServicioAula servicioAula)
        {
            _servicioAula = servicioAula;
        }

        // GET: api/Aulas?busca=Laboratorio
        [HttpGet]
        public async Task<IActionResult> ObtenerTodas([FromQuery] string? busca)
        {
            try
            {
                var aulas = await _servicioAula.ObtenerAulasAsync(busca);
                return Ok(aulas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // POST: api/Aulas
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Aula aula)
        {
            try
            {
                var idGenerado = await _servicioAula.CrearAulaAsync(aula);
                return Ok(new { mensaje = "Aula creada exitosamente", id = idGenerado });
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

        // PUT: api/Aulas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] Aula aula)
        {
            try
            {
                aula.IdAula = id;
                var aulaActualizada = await _servicioAula.ActualizarAulaAsync(aula);
                return Ok(new { mensaje = "Aula actualizada exitosamente", datos = aulaActualizada });
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