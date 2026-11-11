using IES_CREA.API.DTOs.Persona;
using IES_CREA.CORE.Entidades;
using IES_CREA.CORE.Servicios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace IES_CREA.API.Controllers.Personas
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocentesController : ControllerBase
    {
        private readonly ServicioPersona _servicioPersona;

        public DocentesController(ServicioPersona servicioPersona)
        {
            _servicioPersona = servicioPersona;
        }

        // GET: api/Docentes
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            try
            {
                // A futuro: Aquí podrías llamar a un ServicioDocente o reutilizar el de persona
                // var docentes = await _servicioPersona.ObtenerTodosAsync();
                return Ok(new { mensaje = "Lista de docentes (Por implementar)" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // POST: api/Docentes
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] PersonaCrearDto dto) // Reutilizamos el DTO por ahora
        {
            // Aquí deberías validar con FluentValidation (igual que en Alumnos)
            try
            {
                // 1. Mapear a entidad Docente (o Persona si Docente hereda de Persona)
                var nuevoDocente = new Persona
                {
                    Nombre = dto.Nombre,
                    Apellido = dto.Apellido,
                    Dni = dto.Dni,
                    // ... etc
                };

                // 2. Llamar al servicio (a futuro deberías tener un CrearDocenteAsync)
                // var resultado = await _servicioPersona.CrearDocenteAsync(nuevoDocente);

                return Ok(new { mensaje = "Docente creado exitosamente", datos = nuevoDocente });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
    }
}