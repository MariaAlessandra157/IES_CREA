using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using IES_CREA.API.DTOs.Personas;
using IES_CREA.CORE.Entidades;
using IES_CREA.CORE.Servicios;

namespace IES_CREA.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hola mundo del IES";
        }

        [HttpPost]
        public string Post() {
            return "Este metodo guarda informacion";
        }
    }
}
