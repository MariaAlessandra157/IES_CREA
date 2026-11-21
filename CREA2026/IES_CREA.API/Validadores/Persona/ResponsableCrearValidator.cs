using FluentValidation;
using IES_CREA.API.DTOs.Persona;

namespace IES_CREA.API.Validators
{
    public class ResponsableCrearValidator : AbstractValidator<ResponsableCrearDto>
    {
        public ResponsableCrearValidator()
        {
            RuleFor(x => x.IdPersona)
                .GreaterThan(0).WithMessage("El ID de la persona es obligatorio.");
        }
    }
}
