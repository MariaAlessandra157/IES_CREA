using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using IES_CREA.CORE.Servicios;
using IES_CREA.CORE.Entidades;
using IES_CREA.API.DTOs.Persona;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IES_CREA.API.Controllers.Personas
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsableController : ControllerBase
    {
        private readonly ServicioResponsable _servicioResponsable;
        private readonly IMapper _mapper;

        public ResponsableController(ServicioResponsable servicioResponsable, IMapper mapper)
        {
            _servicioResponsable = servicioResponsable;
            _mapper = mapper;
        }

        // GET: api/Responsable/5
        [HttpGet("{idResponsable}")]
        public async Task<IActionResult> Obtener(int idResponsable)
        {
            try
            {
                var responsables = await _servicioResponsable.ObtenerResponsablesAsync(idResponsable);
                var responsablesDto = _mapper.Map<IEnumerable<ResponsableDto>>(responsables);
                return Ok(responsablesDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // POST: api/Responsable
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] ResponsableCrearDto dto)
        {
            try
            {
                var responsable = _mapper.Map<Responsable>(dto);
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

        // PUT: api/Responsable
        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] ResponsableActualizarDto dto)
        {
            try
            {
                var responsable = _mapper.Map<Responsable>(dto);
                var responsableActualizado = await _servicioResponsable.ActualizarResponsableAsync(responsable.IdResponsable, responsable);
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