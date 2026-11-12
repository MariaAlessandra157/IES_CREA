using IES_CREA.CORE.Entidades;
using IES_CREA.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IES_CREA.CORE.Servicios
{
    public class ServicioResponsable
    {
        private readonly IRepositorioResponsable _repositorio;

        public ServicioResponsable(IRepositorioResponsable repositorio)
        {
            _repositorio = repositorio;
        }

        // 1. Obtener responsables (por ID o todos)
        public async Task<IEnumerable<Responsable>> ObtenerResponsablesAsync(int idResponsable)
        {
            return await _repositorio.sp_responsable_consultar(idResponsable);
        }

        // 2. Crear Responsable (con reglas de negocio)
        public async Task<int> CrearResponsableAsync(Responsable responsable)
        {
            // Regla 1: Debe tener una persona asociada
            if (responsable.IdPersona <= 0)
            {
                throw new ArgumentException("El responsable debe estar asociado a una persona válida.");
            }

            // Regla 2: Validar que la persona exista (opcional, requeriría inyectar IRepositorioPersona)
            // var persona = await _repositorioPersona.ObtenerPersonaPorId(responsable.IdPersona);
            // if (persona == null) throw new ArgumentException("La persona no existe en el sistema.");

            return await _repositorio.sp_responsable_insertar(responsable);
        }

        // 3. Actualizar Responsable
        public async Task<Responsable> ActualizarResponsableAsync(int idResponsable, Responsable responsable)
        {
            if (idResponsable <= 0)
            {
                throw new ArgumentException("El ID del responsable es inválido.");
            }

            responsable.IdResponsable = idResponsable;
            return await _repositorio.sp_responsable_actualizar(idResponsable);
        }
    }
}