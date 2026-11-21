using FluentValidation;
using IES_CREA.API.DTOs.Persona;

namespace IES_CREA.API.Validators
{
    public class PersonalCrearValidator : AbstractValidator<PersonalCrearDto>
    {
        public PersonalCrearValidator()
        {
            RuleFor(x => x.IdPersona)
                .GreaterThan(0).WithMessage("El ID de la persona es obligatorio.");

            RuleFor(x => x.IdCargo)
                .GreaterThan(0).WithMessage("El ID del cargo es obligatorio.");

            RuleFor(x => x.FechaIngreso)
                .NotEmpty().WithMessage("La fecha de ingreso es obligatoria.");
        }
    }
}
