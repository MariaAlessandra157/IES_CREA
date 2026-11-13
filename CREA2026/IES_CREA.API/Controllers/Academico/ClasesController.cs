using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using IES_CREA.CORE.Servicios;
using System.Linq;
using IES_CREA.CORE.Entidades;
using IES_CREA.API.DTOs.Academico;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IES_CREA.API.Controllers.Academico
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClasesController : ControllerBase
    {
        private readonly ServicioClase _servicioClase;
        private readonly IMapper _mapper;

        public ClasesController(ServicioClase servicioClase, IMapper mapper)
        {
            _servicioClase = servicioClase;
            _mapper = mapper;
        }

        // GET: api/Clases/5
        [HttpGet("{idClase}")]
        public async Task<IActionResult> Obtener(int idClase)
        {
            try
            {
                var clases = await _servicioClase.ObtenerClasesAsync(idClase);

                if (idClase > 0)
                {
                    var clase = clases.FirstOrDefault();
                    if (clase == null) return NotFound("Clase no encontrada");

                    var claseDto = _mapper.Map<ClaseDto>(clase);
                    return Ok(claseDto);
                }

                // Si idClase es 0, devolvemos la lista completa
                var clasesDto = _mapper.Map<IEnumerable<ClaseDto>>(clases);
                return Ok(clasesDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // POST: api/Clases
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] ClaseCrearDto dto)
        {
            try
            {
                var clase = _mapper.Map<Clase>(dto);
                clase.Estado = true; // Por defecto activa

                var idGenerado = await _servicioClase.CrearClaseAsync(clase);
                return Ok(new { mensaje = "Clase creada exitosamente", id = idGenerado });
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

        // PUT: api/Clases
        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] ClaseActualizarDto dto)
        {
            try
            {
                var clase = _mapper.Map<Clase>(dto);
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
        // DELETE: api/Clases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Desactivar(int id)
        {
            try
            {
                var resultado = await _servicioClase.DesactivarClaseAsync(id);

                if (resultado)
                {
                    return Ok(new { mensaje = "Clase desactivada exitosamente (borrado lógico)." });
                }

                return NotFound("Clase no encontrada.");
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