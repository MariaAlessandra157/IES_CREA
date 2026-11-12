using System;
using System.Collections.Generic;
using System.Text;
using IES_CREA.CORE.Interfaces;
using IES_CREA.CORE.Interfaces.Conexion;
using IES_CREA.infrastructure.Contexto;
using IES_CREA.infrastructure.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using IES_CREA.CORE.Servicios;

namespace IES_CREA.infrastructure.ExtensionesServicios
{
    public static class ExtencionServicio
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException(
                    "La cadena de conexion 'DefaultConnection' no esta configurada."
                 );

            services.AddSingleton<IMyConexion>(new MyConexion(connectionString));

            services.AddScoped<IRepositorioAlumnoResponsable, RepositorioAlumnoResponsable>();
            services.AddScoped<IRepositorioAlumnos, RepositorioAlumno>();
            services.AddScoped<IRepositorioAranceles, RepositorioAranceles>();
            services.AddScoped<IRepositorioAsistencias, RepositorioAsistencias>();
            services.AddScoped<IRepositorioAulas, RepositorioAulas>();
            services.AddScoped<IRepositorioCargos, RepositorioCargos>();
            services.AddScoped<IRepositorioClaseAlumno, RepositorioClaseAlumno>();
            services.AddScoped<IRepositorioClases, RepositorioClases>();
            services.AddScoped<IRepositorioCuotas, RepositorioCuotas>();
            services.AddScoped<IRepositorioCursos, RepositorioCursos>();
            services.AddScoped<IRepositorioDisponibilidadDocente, RepositorioDisponibilidadDocentes>();
            services.AddScoped<IRepositorioDocenteMateria, RepositorioDocenteMateria>();
            services.AddScoped<IRepositorioDocentes, RepositorioDocentes>();
            services.AddScoped<IRepositorioInscripciones, RepositorioInscripciones>();
            services.AddScoped<IRepositorioInscripcionMateria, RepositorioInscripcionMateria>();
            services.AddScoped<IRepositorioInstitucionEducativa, RepositorioInstitucionEducativa>();
            services.AddScoped<IRepositorioMaterias, RepositorioMaterias>();
            services.AddScoped<IRepositorioNivelEducativo, RepositorioNivelEducativo>();
            services.AddScoped<IRepositorioPagos, RepositorioPagos>();
            services.AddScoped<IRepositorioPersona, RepositorioPersona>();
            services.AddScoped<IRepositorioPersonal, RepositorioPersonal>();
            services.AddScoped<IRepositorioResponsable, RepositorioResponsable>();
            services.AddScoped<IRepositorioRoles, RepositorioRol>();
            services.AddScoped<IRepositorioSeguimientoPedagogico, RepositorioSeguimientoPedagogico>();
            services.AddScoped<IRepositorioTrayectoriaEducativa, RepositorioTrayectoriaEducativa>();
            services.AddScoped<IRepositorioUsuarioRol, RepositorioUsuarioRol>();
            services.AddScoped<IRepositorioUsuarios, RepositorioUsuarios>();
            services.AddScoped<ServicioPersona>();
            services.AddScoped<IES_CREA.CORE.Servicios.ServicioPersona>();
            services.AddScoped<IES_CREA.CORE.Servicios.ServicioMateria>();
            services.AddScoped<IES_CREA.CORE.Servicios.ServicioAula>();
            services.AddScoped<IES_CREA.CORE.Servicios.ServicioClase>();
            services.AddScoped<IES_CREA.CORE.Servicios.ServicioCurso>();
            services.AddScoped<IES_CREA.CORE.Servicios.ServicioInscripcion>();
            services.AddScoped<IES_CREA.CORE.Servicios.ServicioArancel>();
            services.AddScoped<IES_CREA.CORE.Servicios.ServicioCuota>();
            services.AddScoped<IES_CREA.CORE.Servicios.ServicioPago>();
            services.AddScoped<IES_CREA.CORE.Servicios.ServicioPersonal>();
            services.AddScoped<IES_CREA.CORE.Servicios.ServicioResponsable>();
            services.AddScoped<IES_CREA.CORE.Servicios.ServicioSeguimiento>();
            services.AddScoped<IES_CREA.CORE.Servicios.ServicioTrayectoria>();
            services.AddScoped<IES_CREA.CORE.Servicios.ServicioRol>();
            services.AddScoped<IES_CREA.CORE.Servicios.ServicioUsuario>();
            // (Si luego creas ServicioAlumno, ServicioCurso, etc., los agregas aquí también)
            return services;
        }

        //Falta hacer la inyeccion de dependencias de los servicios de infraestructura, como repositorios, servicios de correo, etc.
    }
}

