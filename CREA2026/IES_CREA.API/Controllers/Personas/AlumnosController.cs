using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using FluentValidation.Results;
using IES_CREA.API.DTOs.Persona; // Asumimos que tus DTOs están aquí
using IES_CREA.CORE.Servicios;

namespace IES_CREA.API.Controllers.Personas
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        // 1. Inyectamos las dependencias (Servicio y Validador)
        private readonly ServicioPersona _servicioPersona;
        private readonly IValidator<PersonaCrearDto> _validator;

        public AlumnosController(ServicioPersona servicioPersona, IValidator<PersonaCrearDto> validator)
        {
            _servicioPersona = servicioPersona;
            _validator = validator;
        }

        // GET: api/Alumnos
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            // TODO: Aquí llamarías a tu servicio para traer todos los alumnos de la BD.
            // var alumnos = await _servicioPersona.ObtenerTodosLosAlumnosAsync();
            // return Ok(alumnos);

            return Ok(new { mensaje = "Lista de todos los alumnos (Por implementar)" });
        }

        // GET: api/Alumnos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            // TODO: var alumno = await _servicioPersona.ObtenerAlumnoPorIdAsync(id);
            // if (alumno == null) return NotFound("Alumno no encontrado");
            // return Ok(alumno);

            return Ok(new { mensaje = $"Datos del alumno con ID {id} (Por implementar)" });
        }

        // POST: api/Alumnos
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] PersonaCrearDto dto)
        {
            // 1. Validar los datos del DTO usando FluentValidation
            ValidationResult validationResult = await _validator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                // Si hay errores, devolvemos un 400 Bad Request con los mensajes
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
            }

            // 2. Llamar al servicio para guardar en la base de datos
            try
            {
                // TODO: Aquí llamas a tu método real: var nuevoAlumno = await _servicioPersona.CrearAlumnoAsync(dto);

                // Simulamos la respuesta exitosa por ahora
                return Ok(new { mensaje = "Alumno creado exitosamente", datos = dto });
            }
            catch (Exception ex)
            {
                // Manejo de errores (podrías tener un logger aquí)
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // PUT: api/Alumnos/5 (Actualizar)
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] PersonaActualizarDto dto)
        {
            // Aquí iría la lógica para actualizar
            return Ok(new { mensaje = $"Alumno con ID {id} actualizado (Por implementar)" });
        }

        // DELETE: api/Alumnos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            // Aquí iría la lógica para eliminar
            return Ok(new { mensaje = $"Alumno con ID {id} eliminado (Por implementar)" });
        }
    }
}