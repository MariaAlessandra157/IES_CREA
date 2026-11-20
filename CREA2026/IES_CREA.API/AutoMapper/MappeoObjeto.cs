using AutoMapper;
using IES_CREA.API.DTOs.Academico;
using IES_CREA.API.DTOs.Finanzas;
using IES_CREA.API.DTOs.Persona;
using IES_CREA.API.DTOs.Sistema;
using IES_CREA.CORE.Entidades;

namespace IES_CREA.API.AutoMapper
{
    public class MappeoObjeto : Profile
    {
        public MappeoObjeto()
        {
            // ==========================================
            // MAPEOS DE PERSONA
            // ==========================================
            CreateMap<Persona, PersonaDto>().ReverseMap();
            CreateMap<PersonaCrearDto, Persona>();
            CreateMap<PersonaActualizarDto, Persona>();

            // ==========================================
            // MAPEOS ACADÉMICOS
            // ==========================================
            CreateMap<Aula, AulaDto>().ReverseMap();
            CreateMap<AulaCrearDto, Aula>();
            CreateMap<AulaActualizarDto, Aula>();

            CreateMap<Curso, CursoDto>().ReverseMap();
            CreateMap<CursoCrearDto, Curso>();
            CreateMap<CursoActualizarDto, Curso>();

            CreateMap<Materia, MateriaDto>().ReverseMap();
            CreateMap<MateriaCrearDto, Materia>();
            CreateMap<MateriaActualizarDto, Materia>();

            CreateMap<Inscripcion, InscripcionDto>().ReverseMap();
            CreateMap<InscripcionCrearDto, Inscripcion>();
            CreateMap<InscripcionActualizarDto, Inscripcion>();

            CreateMap<Clase, ClaseDto>().ReverseMap();
            CreateMap<ClaseCrearDto, Clase>();
            CreateMap<ClaseActualizarDto, Clase>();

            CreateMap<Seguimiento, SeguimientoDto>().ReverseMap();
            CreateMap<SeguimientoCrearDto, Seguimiento>();
            CreateMap<SeguimientoActualizarDto, Seguimiento>();

            CreateMap<Trayectoria, TrayectoriaDto>().ReverseMap();
            CreateMap<TrayectoriaCrearDto, Trayectoria>();
            CreateMap<TrayectoriaActualizarDto, Trayectoria>();

            // ==========================================
            // MAPEOS DE PERSONAS (ALUMNOS, DOCENTES, ETC)
            // ==========================================
            CreateMap<Alumno, AlumnoDto>().ReverseMap();
            CreateMap<AlumnoCrearDto, Alumno>();
            CreateMap<AlumnoActualizarDto, Alumno>();

            CreateMap<Docente, DocenteDto>().ReverseMap();
            CreateMap<DocenteCrearDto, Docente>();
            CreateMap<DocenteActualizarDto, Docente>();

            CreateMap<Personal, PersonalDto>().ReverseMap();
            CreateMap<PersonalCrearDto, Personal>();
            CreateMap<PersonalActualizarDto, Personal>();

            CreateMap<Responsable, ResponsableDto>().ReverseMap();
            CreateMap<ResponsableCrearDto, Responsable>();
            CreateMap<ResponsableActualizarDto, Responsable>();

            // ==========================================
            // MAPEOS DE FINANZAS
            // ==========================================
            CreateMap<Arancel, ArancelDto>().ReverseMap();
            CreateMap<ArancelCrearDto, Arancel>();
            CreateMap<ArancelActualizarDto, Arancel>();

            CreateMap<Cuota, CuotaDto>().ReverseMap();
            CreateMap<CuotaCrearDto, Cuota>();
            CreateMap<CuotaActualizarDto, Cuota>();

            CreateMap<Pago, PagoDto>().ReverseMap();
            CreateMap<PagoCrearDto, Pago>();
            CreateMap<PagoActualizarDto, Pago>();

            // ==========================================
            // MAPEOS DE SISTEMA (USUARIOS, ROLES)
            // ==========================================
            CreateMap<Rol, RolDto>().ReverseMap();
            CreateMap<RolCrearDto, Rol>();
            CreateMap<RolActualizarDto, Rol>();

            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<UsuarioCrearDto, Usuario>().ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
            CreateMap<UsuarioActualizarDto, Usuario>().ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
        }
    }
}