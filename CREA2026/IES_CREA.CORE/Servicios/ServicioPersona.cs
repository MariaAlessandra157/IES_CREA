using IES_CREA.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace IES_CREA.CORE.Servicios
{
    public class ServicioPersona
    {
        private readonly IRepositorioPersona _repositorio;

        public ServicioPersona(IRepositorioPersona repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<IEnumerable<Persona>> ObtenerPersonaPorId(int p_id)
        {
            return await _repositorio.ObtenerPersonaPorId(p_id);
        }

        public async Task<Persona> GetByIdAsync (int _id)
        {
            if (_id <= 0)
                    throw new ArgumentException("El ID debe ser mayor a 0");
                return await _repositorio.ObtenerPersonaPorId(_id);
        }
    }
}
