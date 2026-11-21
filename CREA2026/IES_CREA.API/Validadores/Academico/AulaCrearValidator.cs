using FluentValidation;
using IES_CREA.API.DTOs.Academico;

namespace IES_CREA.API.Validators
{
    public class AulaCrearValidator : AbstractValidator<AulaCrearDto>
    {
        public AulaCrearValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre del aula es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede superar los 50 caracteres.");

            RuleFor(x => x.Capacidad)
                .NotEmpty().WithMessage("La capacidad es obligatoria.")
                .InclusiveBetween(1, 100).WithMessage("La capacidad debe estar entre 1 y 100.");

            RuleFor(x => x.Descripcion)
                .NotEmpty().WithMessage("La descripción es obligatoria.")
                .MaximumLength(255).WithMessage("La descripción no puede superar los 255 caracteres.");
        }
    }
}