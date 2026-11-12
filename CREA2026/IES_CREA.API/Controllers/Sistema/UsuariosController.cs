using Microsoft.AspNetCore.Mvc;
using IES_CREA.CORE.Servicios;
using IES_CREA.CORE.Entidades;
using System;
using System.Threading.Tasks;

namespace IES_CREA.API.Controllers.Sistema
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ServicioUsuario _servicioUsuario;

        public UsuariosController(ServicioUsuario servicioUsuario)
        {
            _servicioUsuario = servicioUsuario;
        }

        // GET: api/Usuarios/5
        [HttpGet("{idUsuario}")]
        public async Task<IActionResult> Obtener(int idUsuario)
        {
            try
            {
                var usuarios = await _servicioUsuario.ObtenerUsuariosAsync(idUsuario);
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // POST: api/Usuarios
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Usuario usuario)
        {
            try
            {
                // NOTA: Aquí idealmente deberías usar un DTO (UsuarioCrearDto) que reciba "Password" en texto plano,
                // y no la entidad directa con el "PasswordHash".
                var idGenerado = await _servicioUsuario.CrearUsuarioAsync(usuario);
                return Ok(new { mensaje = "Usuario creado exitosamente", id = idGenerado });
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

        // PUT: api/Usuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] Usuario usuario)
        {
            try
            {
                usuario.IdUsuario = id;
                var usuarioActualizado = await _servicioUsuario.ActualizarUsuarioAsync(usuario);
                return Ok(new { mensaje = "Usuario actualizado exitosamente", datos = usuarioActualizado });
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