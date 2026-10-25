using System;
using System.Collections.Generic;
using System.Text;
using IES_CREA.CORE.Interfaces;
using IES_CREA.infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;


namespace IES_CREA.infrastructure.ExtensionesServicios
{
    public static class ExtencionServicio
    {
        public static IServicioCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException(
                    "La cadena de conexion 'DefaultConnection' no esta configurada."
                 );

            services.AddSingleton<IMyConexion>(new MyConexion(connectionString));

            return services;
        }

        //Falta hacer la inyeccion de dependencias de los servicios de infraestructura, como repositorios, servicios de correo, etc.
    }
}
