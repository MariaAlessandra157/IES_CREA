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
    public class SeguimientoPedagogicoController : ControllerBase
    {
        private readonly ServicioSeguimiento _servicioSeguimiento;
        private readonly IMapper _mapper;

        public SeguimientoPedagogicoController(ServicioSeguimiento servicioSeguimiento, IMapper mapper)
        {
            _servicioSeguimiento = servicioSeguimiento;
            _mapper = mapper;
        }

        // GET: api/SeguimientoPedagogico/alumno/5
        [HttpGet("alumno/{idAlumno}")]
        public async Task<IActionResult> ObtenerPorAlumno(int idAlumno)
        {
            try
            {
                var seguimientos = await _servicioSeguimiento.ObtenerPorAlumnoAsync(idAlumno);
                var seguimientosDto = _mapper.Map<IEnumerable<SeguimientoDto>>(seguimientos);
                return Ok(seguimientosDto);
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

        // POST: api/SeguimientoPedagogico
        [HttpPost]
        public async Task<IActionResult> Registrar([FromBody] SeguimientoCrearDto dto)
        {
            try
            {
                var seguimiento = _mapper.Map<Seguimiento>(dto);
                var idGenerado = await _servicioSeguimiento.RegistrarSeguimientoAsync(seguimiento);
                return Ok(new { mensaje = "Seguimiento registrado exitosamente", id = idGenerado });
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

        // PUT: api/SeguimientoPedagogico
        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] SeguimientoActualizarDto dto)
        {
            try
            {
                var seguimiento = _mapper.Map<Seguimiento>(dto);
                var seguimientoActualizado = await _servicioSeguimiento.ActualizarSeguimientoAsync(seguimiento);
                return Ok(new { mensaje = "Seguimiento actualizado exitosamente", datos = seguimientoActualizado });
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