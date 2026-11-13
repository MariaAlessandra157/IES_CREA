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
    public class UsuariosController : ControllerBase
    {
        private readonly ServicioUsuario _servicioUsuario;
        private readonly IMapper _mapper;

        public UsuariosController(ServicioUsuario servicioUsuario, IMapper mapper)
        {
            _servicioUsuario = servicioUsuario;
            _mapper = mapper;
        }

        // GET: api/Usuarios/5
        [HttpGet("{idUsuario}")]
        public async Task<IActionResult> Obtener(int idUsuario)
        {
            try
            {
                var usuarios = await _servicioUsuario.ObtenerUsuariosAsync(idUsuario);
                var usuariosDto = _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);
                return Ok(usuariosDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // POST: api/Usuarios
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] UsuarioCrearDto dto)
        {
            try
            {
                var usuario = _mapper.Map<Usuario>(dto);
                var idGenerado = await _servicioUsuario.CrearUsuarioAsync(usuario, dto.Password);
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

        // PUT: api/Usuarios
        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] UsuarioActualizarDto dto)
        {
            try
            {
                var usuario = _mapper.Map<Usuario>(dto);
                var usuarioActualizado = await _servicioUsuario.ActualizarUsuarioAsync(usuario, dto.Password);
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

        // POST: api/Usuarios/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            try
            {
                var usuario = await _servicioUsuario.LoginAsync(dto.NombreUsuario, dto.Password);
                var usuarioDto = _mapper.Map<UsuarioDto>(usuario);
                return Ok(new { mensaje = "Login exitoso", datos = usuarioDto });
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