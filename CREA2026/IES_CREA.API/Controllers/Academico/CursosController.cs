using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using IES_CREA.CORE.Servicios;
using IES_CREA.CORE.Entidades;
using IES_CREA.API.DTOs.Academico;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IES_CREA.API.Controllers.Academico
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly ServicioCurso _servicioCurso;
        private readonly IMapper _mapper;

        public CursosController(ServicioCurso servicioCurso, IMapper mapper)
        {
            _servicioCurso = servicioCurso;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            try
            {
                var cursos = await _servicioCurso.ObtenerCursosAsync();
                var cursosDto = _mapper.Map<IEnumerable<CursoDto>>(cursos);
                return Ok(cursosDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CursoCrearDto dto)
        {
            try
            {
                var curso = _mapper.Map<Curso>(dto);
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

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] CursoActualizarDto dto)
        {
            try
            {
                var curso = _mapper.Map<Curso>(dto);
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