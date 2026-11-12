using Microsoft.AspNetCore.Mvc;
using IES_CREA.CORE.Servicios;
using IES_CREA.CORE.Entidades;
using System;
using System.Threading.Tasks;

namespace IES_CREA.API.Controllers.Academico
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly ServicioCurso _servicioCurso;

        public CursosController(ServicioCurso servicioCurso)
        {
            _servicioCurso = servicioCurso;
        }

        // GET: api/Cursos
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            try
            {
                var cursos = await _servicioCurso.ObtenerCursosAsync();
                return Ok(cursos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // POST: api/Cursos
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Curso curso)
        {
            try
            {
                var idGenerado = await _servicioCurso.CrearCursoAsync(curso);
                return Ok(new { mensaje = "Curso creado exitosamente", id = idGenerado });
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

        // PUT: api/Cursos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] Curso curso)
        {
            try
            {
                curso.IdCurso = id; // Ajusta según tu entidad
                var cursoActualizado = await _servicioCurso.ActualizarCursoAsync(curso);
                return Ok(new { mensaje = "Curso actualizado exitosamente", datos = cursoActualizado });
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