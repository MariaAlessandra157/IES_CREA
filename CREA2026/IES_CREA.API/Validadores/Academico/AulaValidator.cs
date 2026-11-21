using FluentValidation;
using IES_CREA.API.DTOs.Academico;

namespace IES_CREA.API.Validators.Academico
{
    public class AulaValidator : AbstractValidator<AulaDto>
    {
        public AulaValidator()
        {
            RuleFor(x => x.IdAula)
                .GreaterThan(0).WithMessage("El ID del aula debe ser mayor a 0.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre del aula es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede superar los 50 caracteres.");

            RuleFor(x => x.Capacidad)
                .InclusiveBetween(1, 100).WithMessage("La capacidad debe estar entre 1 y 100.");

            RuleFor(x => x.Descripcion)
                .MaximumLength(255).WithMessage("La descripción no puede superar los 255 caracteres.");
        }
    }
}
