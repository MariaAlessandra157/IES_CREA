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
    public class MateriasController : ControllerBase
    {
        private readonly ServicioMateria _servicioMateria;
        private readonly IMapper _mapper; // Inyectamos AutoMapper

        public MateriasController(ServicioMateria servicioMateria, IMapper mapper)
        {
            _servicioMateria = servicioMateria;
            _mapper = mapper;
        }

        // GET: api/Materias
        [HttpGet]
        public async Task<IActionResult> ObtenerTodas()
        {
            try
            {
                var materias = await _servicioMateria.ObtenerTodasAsync();
                var materiasDto = _mapper.Map<IEnumerable<MateriaDto>>(materias);
                return Ok(materiasDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // POST: api/Materias
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] MateriaCrearDto dto)
        {
            try
            {
                var materia = _mapper.Map<Materia>(dto);
                materia.Activo = true; // Por defecto activa

                var idGenerado = await _servicioMateria.CrearMateriaAsync(materia);
                return Ok(new { mensaje = "Materia creada exitosamente", id = idGenerado });
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

        // PUT: api/Materias
        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] MateriaActualizarDto dto)
        {
            try
            {
                var materia = _mapper.Map<Materia>(dto);
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
        // DELETE: api/Materias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Desactivar(int id)
        {
            try
            {
                var resultado = await _servicioMateria.DesactivarMateriaAsync(id);

                if (resultado)
                {
                    return Ok(new { mensaje = "Materia desactivada exitosamente (borrado lógico)." });
                }

                return NotFound("Materia no encontrada.");
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