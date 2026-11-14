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
    public class PersonalController : ControllerBase
    {
        private readonly ServicioPersonal _servicioPersonal;
        private readonly IMapper _mapper;

        public PersonalController(ServicioPersonal servicioPersonal, IMapper mapper)
        {
            _servicioPersonal = servicioPersonal;
            _mapper = mapper;
        }

        // GET: api/Personal/5
        [HttpGet("{idPersonal}")]
        public async Task<IActionResult> Obtener(int idPersonal)
        {
            try
            {
                var personal = await _servicioPersonal.ObtenerPersonalAsync(idPersonal);
                var personalDto = _mapper.Map<IEnumerable<PersonalDto>>(personal);
                return Ok(personalDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // POST: api/Personal
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] PersonalCrearDto dto)
        {
            try
            {
                var personal = _mapper.Map<Personal>(dto);
                personal.Activo = true;

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

        // PUT: api/Personal
        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] PersonalActualizarDto dto)
        {
            try
            {
                var personal = _mapper.Map<Personal>(dto);
                var personalActualizado = await _servicioPersonal.ActualizarPersonalAsync(personal.IdPersonal, personal);
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