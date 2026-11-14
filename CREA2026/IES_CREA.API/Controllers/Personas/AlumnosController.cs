using AutoMapper;
using FluentValidation;
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
    public class AlumnosController : ControllerBase
    {
        private readonly ServicioAlumno _servicioAlumno;
        private readonly IMapper _mapper;

        public AlumnosController(ServicioAlumno servicioAlumno, IMapper mapper)
        {
            _servicioAlumno = servicioAlumno;
            _mapper = mapper;
        }

        // GET: api/Alumnos
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            try
            {
                var alumnos = await _servicioAlumno.ObtenerTodosAsync();
                var alumnosDto = _mapper.Map<IEnumerable<AlumnoDto>>(alumnos);
                return Ok(alumnosDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // POST: api/Alumnos
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] AlumnoCrearDto dto)
        {
            try
            {
                var alumno = _mapper.Map<Alumno>(dto);
                alumno.Activo = true; // Por defecto activo

                var idGenerado = await _servicioAlumno.CrearAlumnoAsync(alumno);
                return Ok(new { mensaje = "Alumno creado exitosamente", id = idGenerado });
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

        // PUT: api/Alumnos (según tu interfaz, recibe un string)
        [HttpPut("{busca}")]
        public async Task<IActionResult> Actualizar(string busca)
        {
            try
            {
                var alumnosActualizados = await _servicioAlumno.ActualizarAlumnoAsync(busca);
                return Ok(new { mensaje = "Alumnos actualizados exitosamente", datos = alumnosActualizados });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
    }
}