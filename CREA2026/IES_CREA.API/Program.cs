using FluentValidation;
using IES_CREA.API;
using IES_CREA.API.AutoMapper;
using IES_CREA.API.DTOs;
using IES_CREA.API.DTOs.Academico;
using IES_CREA.API.DTOs.Finanzas;
using IES_CREA.API.DTOs.Persona;
using IES_CREA.API.DTOs.Sistema;
using IES_CREA.API.Validators;
using IES_CREA.API.Validators.Academico;
using IES_CREA.CORE.Servicios;
using IES_CREA.infrastructure.ExtensionesServicios;
using Microsoft.AspNetCore.OpenApi;

namespace IES_CREA.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappeoObjeto>());
            builder.Services.AddScoped<IValidator<PersonaCrearDto>, PersonaCrearValidator>();

            // 2. Registramos AutoMapper (¡NUEVO!)
            builder.Services.AddAutoMapper(cfg => { }, typeof(MappeoObjeto).Assembly);

            // 1. Inyección de Infraestructura (Repositorios y Servicios de CORE)

            builder.Services.AddInfrastructure(builder.Configuration);

            // 2. Inyección de la API (Validadores)
            builder.Services.AddAPI();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();

            // Registro de Validadores de FluentValidation
            builder.Services.AddScoped<IValidator<AulaCrearDto>, AulaCrearValidator>();
            builder.Services.AddScoped<IValidator<AulaActualizarDto>, AulaActualizarValidator>();
            builder.Services.AddScoped<IValidator<AulaDto>, AulaValidator>();
            builder.Services.AddScoped<IValidator<ClaseCrearDto>, ClaseCrearValidator>();
            builder.Services.AddScoped<IValidator<ClaseActualizarDto>, ClaseActualizarValidator>();
            builder.Services.AddScoped<IValidator<ClaseDto>, ClaseValidator>();
            builder.Services.AddScoped<IValidator<CursoCrearDto>, CursoCrearValidator>();
            builder.Services.AddScoped<IValidator<CursoActualizarDto>, CursoActualizarValidator>();
            builder.Services.AddScoped<IValidator<CursoDto>, CursoValidator>();
            builder.Services.AddScoped<IValidator<InscripcionCrearDto>, InscripcionCrearValidator>();
            builder.Services.AddScoped<IValidator<InscripcionActualizarDto>, InscripcionActualizarValidator>();
            builder.Services.AddScoped<IValidator<InscripcionDto>, InscripcionValidator>();
            builder.Services.AddScoped<IValidator<MateriaCrearDto>, MateriaCrearValidator>();
            builder.Services.AddScoped<IValidator<MateriaActualizarDto>, MateriaActualizarValidator>();
            builder.Services.AddScoped<IValidator<MateriaDto>, MateriaValidator>();
            builder.Services.AddScoped<IValidator<AlumnoCrearDto>, AlumnoCrearValidator>();
            builder.Services.AddScoped<IValidator<AlumnoActualizarDto>, AlumnoActualizarValidator>();
            builder.Services.AddScoped<IValidator<AlumnoDto>, AlumnoValidator>();
            builder.Services.AddScoped<IValidator<DocenteCrearDto>, DocenteCrearValidator>();
            builder.Services.AddScoped<IValidator<DocenteActualizarDto>, DocenteActualizarValidator>();
            builder.Services.AddScoped<IValidator<DocenteDto>, DocenteValidator>();
            builder.Services.AddScoped<IValidator<PersonaCrearDto>, PersonaCrearValidator>();
            builder.Services.AddScoped<IValidator<PersonaActualizarDto>, PersonaActualizarValidator>();
            builder.Services.AddScoped<IValidator<PersonaDto>, PersonaValidator>();
            builder.Services.AddScoped<IValidator<ResponsableCrearDto>, ResponsableCrearValidator>();
            builder.Services.AddScoped<IValidator<ResponsableActualizarDto>, ResponsableActualizarValidator>();
            builder.Services.AddScoped<IValidator<ResponsableDto>, ResponsableValidator>();
            builder.Services.AddScoped<IValidator<PersonalCrearDto>, PersonalCrearValidator>();
            builder.Services.AddScoped<IValidator<PersonalActualizarDto>, PersonalActualizarValidator>();
            builder.Services.AddScoped<IValidator<PersonalDto>, PersonalValidator>();
            builder.Services.AddScoped<IValidator<ArancelCrearDto>, ArancelCrearValidator>();
            builder.Services.AddScoped<IValidator<ArancelActualizarDto>, ArancelActualizarValidator>();
            builder.Services.AddScoped<IValidator<ArancelDto>, ArancelValidator>();
            builder.Services.AddScoped<IValidator<CuotaCrearDto>, CuotaCrearValidator>();
            builder.Services.AddScoped<IValidator<CuotaActualizarDto>, CuotaActualizarValidator>();
            builder.Services.AddScoped<IValidator<CuotaDto>, CuotaValidator>();
            builder.Services.AddScoped<IValidator<PagoCrearDto>, PagoCrearValidator>();
            builder.Services.AddScoped<IValidator<PagoActualizarDto>, PagoActualizarValidator>();
            builder.Services.AddScoped<IValidator<PagoDto>, PagoValidator>();
            builder.Services.AddScoped<IValidator<SeguimientoCrearDto>, SeguimientoCrearValidator>();
            builder.Services.AddScoped<IValidator<SeguimientoActualizarDto>, SeguimientoActualizarValidator>();
            builder.Services.AddScoped<IValidator<SeguimientoDto>, SeguimientoValidator>();
            builder.Services.AddScoped<IValidator<TrayectoriaCrearDto>, TrayectoriaCrearValidator>();
            builder.Services.AddScoped<IValidator<TrayectoriaActualizarDto>, TrayectoriaActualizarValidator>();
            builder.Services.AddScoped<IValidator<TrayectoriaDto>, TrayectoriaValidator>();
            builder.Services.AddScoped<IValidator<LoginDto>, LoginValidator>();
            builder.Services.AddScoped<IValidator<RolCrearDto>, RolCrearValidator>();
            builder.Services.AddScoped<IValidator<RolActualizarDto>, RolActualizarValidator>();
            builder.Services.AddScoped<IValidator<RolDto>, RolValidator>();
            builder.Services.AddScoped<IValidator<UsuarioCrearDto>, UsuarioCrearValidator>();
            builder.Services.AddScoped<IValidator<UsuarioActualizarDto>, UsuarioActualizarValidator>();
            builder.Services.AddScoped<IValidator<UsuarioDto>, UsuarioValidator>();
            builder.Services.AddScoped<IValidator<ResponsableCrearDto>, ResponsableCrearValidator>();
            builder.Services.AddScoped<IValidator<ResponsableActualizarDto>, ResponsableActualizarValidator>();
            builder.Services.AddScoped<IValidator<ResponsableDto>, ResponsableValidator>();
        }
    }
}