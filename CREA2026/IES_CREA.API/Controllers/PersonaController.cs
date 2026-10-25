using AutoMapper;
using FluentValidation;
using IES_CREA.API.DTOs;
using IES_CREA.API.DTOs.Persona;
using IES_CREA.CORE.Entidades;
using IES_CREA.CORE.Interfaces;
using IES_CREA.CORE.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Threading.Tasks;

namespace IES_CREA.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly ServicioPersona _servicio;
        private IValidator<CrearPersonaDto> _validatorCrearPersona;
        private IValidator<PersonaActualizarDto> _validatorActualizarPerson;
        private IMapper _mapper;

        public PersonaController(
            ServicioPersona servicioPersona,
            IRepositorioPersona repositorioPersona,
            IMapper mapper,
            IValidator<CrearPersonaDto> validator)
        {
            _servicioPersona = servicioPersona;
            _repositorioPersona = repositorioPersona;
            _mapper = mapper;
            _validator = validator;
        }

        // GET: api/Persona/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var persona = await _servicioPersona.GetByIdAsync(id);

            if (persona == null)
                return NotFound($"No se encontró la persona con ID {id}");

            // Convertimos la Entidad a DTO
            var personaDto = _mapper.Map<PersonaDto>(persona);
            return Ok(personaDto);
        }

        // POST: api/Persona
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CrearPersonaDto crearPersonaDto)
        {
            // 1. Validamos con FluentValidation
            var validationResult = await _validator.ValidateAsync(crearPersonaDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            // 2. Mapeamos DTO a Entidad
            var personaEntidad = _mapper.Map<Persona>(crearPersonaDto);

            // 3. Llamamos al repositorio para guardar
            var resultado = await _repositorioPersona.sp_persona_insertar(personaEntidad);

            if (resultado > 0)
            {
                // Retornamos el objeto mapeado de vuelta (opcional)
                return Ok(new { mensaje = "Creado exitosamente", id = resultado });
            }

            return BadRequest("No se pudo crear la persona.");
        }
    }
}
