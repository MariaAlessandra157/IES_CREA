using FluentValidation;
using IES_CREA.API.AutoMapper;
using IES_CREA.API.DTOs;
using IES_CREA.API.Validators;
using IES_CREA.CORE.Servicios;
using IES_CREA.infrastructure.ExtensionesServicios;

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
            builder.Services.AddScoped<IValidator<PersonaCrearDto>, CrearPersonaValidator>();
            builder.Services.AddInfrastructure(builder.Configuration);

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

