using IES_CREA.CORE.Entidades;
using IES_CREA.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IES_CREA.CORE.Servicios
{
    public class ServicioUsuario
    {
        private readonly IRepositorioUsuarios _repositorio;

        public ServicioUsuario(IRepositorioUsuarios repositorio)
        {
            _repositorio = repositorio;
        }

        // 1. Obtener usuarios
        public async Task<IEnumerable<Usuario>> ObtenerUsuariosAsync(int idUsuario)
        {
            return await _repositorio.sp_usuario_cosultar(idUsuario);
        }

        // 2. Crear Usuario
        public async Task<int> CrearUsuarioAsync(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.NombreUsuario))
                throw new ArgumentException("El nombre de usuario es obligatorio.");

            // AQUÍ IRÍA LA LÓGICA DE ENCRIPTACIÓN
            // usuario.PasswordHash = BCrypt.Net.BCrypt.HashPassword(usuario.PasswordHash);

            // Regla: El usuario debe estar activo por defecto al crearse
            usuario.Activo = true;
            usuario.FechaCreacion = DateOnly.FromDateTime(DateTime.Today);

            return await _repositorio.sp_usuario_crear(usuario);
        }

        // 3. Actualizar Usuario
        public async Task<Usuario> ActualizarUsuarioAsync(Usuario usuario)
        {
            if (usuario.IdUsuario <= 0)
                throw new ArgumentException("El ID del usuario es inválido.");

            return await _repositorio.sp_usuario_actualizar(usuario);
        }

        // 4. Login (Lógica de negocio)
        public async Task<Usuario> LoginAsync(string nombreUsuario, string password)
        {
            // 1. Buscamos al usuario (asumiendo que cambiamos el método del repo a string)
            // var usuario = await _repositorio.sp_usuario_login(nombreUsuario);

            // 2. Si el usuario no existe o está inactivo, error
            // if (usuario == null || !usuario.Activo)
            //     throw new ArgumentException("Usuario o contraseña incorrectos.");

            // 3. Verificar la contraseña (ejemplo con BCrypt)
            // bool passwordValido = BCrypt.Net.BCrypt.Verify(password, usuario.PasswordHash);
            // if (!passwordValido) throw new ArgumentException("Usuario o contraseña incorrectos.");

            // 4. Actualizar fecha de último acceso
            // usuario.UltimoAcceso = DateOnly.FromDateTime(DateTime.Today);
            // await _repositorio.sp_usuario_actualizar(usuario);

            // return usuario;

            throw new NotImplementedException("Falta implementar la lógica de login");
        }
    }
}