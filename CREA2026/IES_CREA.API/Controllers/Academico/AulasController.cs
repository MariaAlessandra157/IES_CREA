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
    public class AulasController : ControllerBase
    {
        private readonly ServicioAula _servicioAula;
        private readonly IMapper _mapper; // <-- Inyectamos AutoMapper

        public AulasController(ServicioAula servicioAula, IMapper mapper)
        {
            _servicioAula = servicioAula;
            _mapper = mapper;
        }

        // GET: api/Aulas?busca=Laboratorio
        [HttpGet]
        public async Task<IActionResult> ObtenerTodas([FromQuery] string? busca)
        {
            try
            {
                var aulas = await _servicioAula.ObtenerAulasAsync(busca);
                // Mapeamos la lista de entidades a lista de DTOs
                var aulasDto = _mapper.Map<IEnumerable<AulaDto>>(aulas);
                return Ok(aulasDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // POST: api/Aulas
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] AulaCrearDto dto)
        {
            try
            {
                // Mapeamos el DTO a la Entidad
                var aula = _mapper.Map<Aula>(dto);
                // Por defecto, el aula nueva está activa
                aula.Activo = true;

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

        // PUT: api/Aulas
        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] AulaActualizarDto dto)
        {
            try
            {
                // Mapeamos el DTO a la Entidad (el ID ya viene en el DTO)
                var aula = _mapper.Map<Aula>(dto);

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
        // DELETE: api/Aulas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Desactivar(int id)
        {
            try
            {
                var resultado = await _servicioAula.DesactivarAulaAsync(id);

                if (resultado)
                {
                    return Ok(new { mensaje = "Aula desactivada exitosamente (borrado lógico)." });
                }

                return NotFound("Aula no encontrada.");
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