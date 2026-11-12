<<<<<<< HEAD
using FluentValidation;
using IES_CREA.API.AutoMapper;
using IES_CREA.API.DTOs;
using IES_CREA.API.Validators;
using IES_CREA.CORE.Servicios;
=======
>>>>>>> main
using IES_CREA.infrastructure.ExtensionesServicios;
using IES_CREA.API;

namespace IES_CREA.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
<<<<<<< HEAD
            builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappeoObjeto>());
            builder.Services.AddScoped<IValidator<PersonaCrearDto>, CrearPersonaValidator>();
=======

            // 1. Inyección de Infraestructura (Repositorios y Servicios de CORE)
>>>>>>> main
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
        }
    }
}