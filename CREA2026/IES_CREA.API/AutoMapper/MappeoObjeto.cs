using AutoMapper;
using IES_CREA.API.DTOs;
using IES_CREA.CORE.Entidades;

namespace IES_CREA.API.AutoMapper
{
    public class MappeoObjeto : Profile
    {
        public MappeoObjeto()
        {
            CreateMap<PersonaDto, Persona>();
            CreateMap<PersonaCrearDto, Persona>();
            CreateMap<PersonaActualizarDto, Persona>();

        }
    }
}
