using Microsoft.AspNetCore.Mvc;
using IES_CREA.CORE.Servicios;
using IES_CREA.CORE.Entidades;
using System;
using System.Threading.Tasks;

namespace IES_CREA.API.Controllers.Sistema
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly ServicioRol _servicioRol;

        public RolesController(ServicioRol servicioRol)
        {
            _servicioRol = servicioRol;
        }

        // GET: api/Roles?busca=Admin
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos([FromQuery] string? busca)
        {
            try
            {
                var roles = await _servicioRol.ObtenerRolesAsync(busca);
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // POST: api/Roles
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Rol rol)
        {
            try
            {
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