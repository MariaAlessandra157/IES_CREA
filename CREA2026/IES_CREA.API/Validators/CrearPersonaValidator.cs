
using FluentValidation;
using IES_CREA.API.DTOs;

namespace IES_CREA.API.Validators
{
    public class CrearPersonaValidator : AbstractValidator<PersonaCrearDto>
    {
        public CrearPersonaValidator()
        {
            RuleFor(x => x.Dni).NotEmpty().WithMessage("El DNI es obligatorio.");
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("El nombre es obligatorio.");
            RuleFor(x => x.Apellido).NotEmpty().WithMessage("El apellido es obligatorio.");
        }
    }
}
