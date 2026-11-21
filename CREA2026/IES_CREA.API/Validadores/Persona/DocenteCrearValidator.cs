using FluentValidation;
using IES_CREA.API.DTOs.Persona;

namespace IES_CREA.API.Validators
{
    public class DocenteCrearValidator : AbstractValidator<DocenteCrearDto>
    {
        public DocenteCrearValidator()
        {
            RuleFor(x => x.IdPersona)
                .GreaterThan(0).WithMessage("El ID de la persona es obligatorio.");

            RuleFor(x => x.Especialidad)
                .NotEmpty().WithMessage("La especialidad es obligatoria.")
                .MaximumLength(100).WithMessage("La especialidad no puede superar los 100 caracteres.");

            RuleFor(x => x.FechaAlta)
                .NotEmpty().WithMessage("La fecha de alta es obligatoria.");
        }
    }
}
