
using FluentValidation;
using IES_CREA.API.DTOsPersona;

namespace IES_CREA.API.Validators
{
    public class CrearPersonaValidator : AbstractValidator<CrearPersonaDto>
    {
            RuleFor(x => x.Dni).NotEmpty().WithMessage("El DNI es obligatorio.");
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("El nombre es obligatorio.");
            RuleFor(x => x.Apellido).NotEmpty().WithMessage("El apellido es obligatorio.");
          
        }
    }
}
