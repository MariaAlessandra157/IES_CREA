using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using IES_CREA.CORE.Servicios;
using IES_CREA.CORE.Entidades;
using IES_CREA.API.DTOs.Sistema;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IES_CREA.API.Controllers.Sistema
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly ServicioRol _servicioRol;
        private readonly IMapper _mapper;

        public RolesController(ServicioRol servicioRol, IMapper mapper)
        {
            _servicioRol = servicioRol;
            _mapper = mapper;
        }

        // GET: api/Roles?busca=Admin
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos([FromQuery] string? busca)
        {
            try
            {
                var roles = await _servicioRol.ObtenerRolesAsync(busca);
                var rolesDto = _mapper.Map<IEnumerable<RolDto>>(roles);
                return Ok(rolesDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // POST: api/Roles
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] RolCrearDto dto)
        {
            try
            {
                var rol = _mapper.Map<Rol>(dto);
                var idGenerado = await _servicioRol.CrearRolAsync(rol);
                return Ok(new { mensaje = "Rol creado exitosamente", id = idGenerado });
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

        // PUT: api/Roles/Admin (según tu interfaz, recibe un string)
        [HttpPut("{busca}")]
        public async Task<IActionResult> Actualizar(string busca)
        {
            try
            {
                var rolesActualizados = await _servicioRol.ActualizarRolAsync(busca);
                return Ok(new { mensaje = "Roles actualizados exitosamente", datos = rolesActualizados });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
    }
}