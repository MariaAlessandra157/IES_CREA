using Microsoft.AspNetCore.Mvc;
using IES_CREA.CORE.Servicios;
using IES_CREA.CORE.Entidades;
using System;
using System.Threading.Tasks;

namespace IES_CREA.API.Controllers.Academico
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClasesController : ControllerBase
    {
        private readonly ServicioClase _servicioClase;

        public ClasesController(ServicioClase servicioClase)
        {
            _servicioClase = servicioClase;
        }

        // GET: api/Clases/5 (Buscar por ID de clase)
        // GET: api/Clases/0 (Traer todas, según cómo esté armado tu SP)
        [HttpGet("{idClase}")]
        public async Task<IActionResult> Obtener(int idClase)
        {
            try
            {
                var clases = await _servicioClase.ObtenerClasesAsync(idClase);
                return Ok(clases);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // POST: api/Clases
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Clase clase)
        {
            try
            {
                var idGenerado = await _servicioClase.CrearClaseAsync(clase);
                return Ok(new { mensaje = "Clase creada exitosamente", id = idGenerado });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // Errores de regla de negocio
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // PUT: api/Clases/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] Clase clase)
        {
            try
            {
                clase.IdClase = id;
                var claseActualizada = await _servicioClase.ActualizarClaseAsync(clase);
                return Ok(new { mensaje = "Clase actualizada exitosamente", datos = claseActualizada });
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