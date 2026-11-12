using FluentValidation;
using IES_CREA.API.Controllers.Personas;

namespace IES_CREA.API
{
    public static class ExtensionesAPI
    {
        public static IServiceCollection AddAPI(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<AlumnosController>();
            return services;
        }
    }
}