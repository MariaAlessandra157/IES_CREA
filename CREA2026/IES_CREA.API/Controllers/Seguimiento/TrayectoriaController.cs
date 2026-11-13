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
    public class TrayectoriaController : ControllerBase
    {
        private readonly ServicioTrayectoria _servicioTrayectoria;
        private readonly IMapper _mapper;

        public TrayectoriaController(ServicioTrayectoria servicioTrayectoria, IMapper mapper)
        {
            _servicioTrayectoria = servicioTrayectoria;
            _mapper = mapper;
        }

        // GET: api/Trayectoria/alumno/5
        [HttpGet("alumno/{idAlumno}")]
        public async Task<IActionResult> ObtenerPorAlumno(int idAlumno)
        {
            try
            {
                var trayectorias = await _servicioTrayectoria.ObtenerPorAlumnoAsync(idAlumno);
                var trayectoriasDto = _mapper.Map<IEnumerable<TrayectoriaDto>>(trayectorias);
                return Ok(trayectoriasDto);
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

        // POST: api/Trayectoria
        [HttpPost]
        public async Task<IActionResult> Registrar([FromBody] TrayectoriaCrearDto dto)
        {
            try
            {
                var trayectoria = _mapper.Map<Trayectoria>(dto);
                var idGenerado = await _servicioTrayectoria.RegistrarTrayectoriaAsync(trayectoria);
                return Ok(new { mensaje = "Trayectoria registrada exitosamente", id = idGenerado });
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

        // PUT: api/Trayectoria
        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] TrayectoriaActualizarDto dto)
        {
            try
            {
                var trayectoria = _mapper.Map<Trayectoria>(dto);
                var trayectoriaActualizada = await _servicioTrayectoria.ActualizarTrayectoriaAsync(trayectoria);
                return Ok(new { mensaje = "Trayectoria actualizada exitosamente", datos = trayectoriaActualizada });
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