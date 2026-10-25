using FluentValidation;
using IES_CREA:API.Validators;
using IES:CREA.CORE.Interfaces;
using IES_CREA.CORE.Servicios;
using Microsoft.AspNetCore.Cors;
using System.Runtime.Versioning;
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

