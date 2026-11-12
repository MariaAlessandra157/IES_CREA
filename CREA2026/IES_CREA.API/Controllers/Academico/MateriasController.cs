using Microsoft.AspNetCore.Mvc;
using IES_CREA.CORE.Servicios;
using IES_CREA.CORE.Entidades;
using System;
using System.Threading.Tasks;

namespace IES_CREA.API.Controllers.Academico
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriasController : ControllerBase
    {
        // Ahora inyectamos el Servicio, no el Repositorio
        private readonly ServicioMateria _servicioMateria;

        public MateriasController(ServicioMateria servicioMateria)
        {
            _servicioMateria = servicioMateria;
        }

        // GET: api/Materias
        [HttpGet]
        public async Task<IActionResult> ObtenerTodas()
        {
            try
            {
                var materias = await _servicioMateria.ObtenerTodasAsync();
                return Ok(materias);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // POST: api/Materias
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Materia materia)
        {
            try
            {
                var idGenerado = await _servicioMateria.CrearMateriaAsync(materia);
                return Ok(new { mensaje = "Materia creada exitosamente", id = idGenerado });
            }
            catch (ArgumentException ex)
            {
                // Errores de validación de negocio devuelven 400 Bad Request
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // PUT: api/Materias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] Materia materia)
        {
            try
            {
                materia.IdMateria = id;
                var materiaActualizada = await _servicioMateria.ActualizarMateriaAsync(materia);
                return Ok(new { mensaje = "Materia actualizada exitosamente", datos = materiaActualizada });
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