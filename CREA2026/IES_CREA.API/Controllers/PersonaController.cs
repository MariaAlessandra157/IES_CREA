using Microsoft.AspNetCore.Mvc;

namespace IES_CREA.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : Controller
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
