using IES_CREA.CORE.Entidades;
using IES_CREA.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IES_CREA.CORE.Servicios
{
    public class ServicioRol
    {
        private readonly IRepositorioRoles _repositorio;

        public ServicioRol(IRepositorioRoles repositorio)
        {
            _repositorio = repositorio;
        }

        // 1. Consultar roles
        public async Task<IEnumerable<Rol>> ObtenerRolesAsync(string busca)
        {
            return await _repositorio.sp_rol_consultar(busca ?? string.Empty);
        }

        // 2. Crear un rol (con reglas de negocio)
        public async Task<int> CrearRolAsync(Rol rol)
        {
            if (string.IsNullOrWhiteSpace(rol.Nombre))
            {
                throw new ArgumentException("El nombre del rol es obligatorio.");
            }

            // Aquí podrías validar que no exista un rol con el mismo nombre
            // var rolesExistentes = await _repositorio.sp_rol_consultar(rol.Nombre);
            // if (rolesExistentes.Any()) throw new ArgumentException("Ya existe un rol con ese nombre.");

            return await _repositorio.sp_rol_insertar(rol);
        }

        // 3. Actualizar un rol (según tu interfaz, recibe un string)
        public async Task<IEnumerable<Rol>> ActualizarRolAsync(string busca)
        {
            return await _repositorio.sp_rol_actualizar(busca);
        }
    }
}