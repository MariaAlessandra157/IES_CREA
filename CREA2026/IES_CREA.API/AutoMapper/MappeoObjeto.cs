using AutoMapper;
using IES_CREA.API.DTOs.Persona;
using IES_CREA.CORE.Entidades;

namespace IES_CREA.API.AutoMapper
{
    public class MappeoObjeto : Profile
    {
        public MappeoObjeto()
        {
            CreateMap<Persona, PersonaDto>();
            CreateMap<PersonaCrearDto, Persona>();
            CreateMap<PersonaActualizarDto, Persona>();
        }
    }
}
