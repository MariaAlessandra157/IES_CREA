using FluentValidation;
using IES_CREA.API.DTOs.Academico;

namespace IES_CREA.API.Validators
{
    public class CursoValidator : AbstractValidator<CursoDto>
    {
        public CursoValidator()
        {
            RuleFor(x => x.IdCurso)
                .GreaterThan(0).WithMessage("El ID del curso es obligatorio.");

            RuleFor(x => x.IdNivel)
                .GreaterThan(0).WithMessage("El ID del nivel educativo es obligatorio.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre del curso es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre del curso no puede superar los 50 caracteres.");

            RuleFor(x => x.Orden)
                .NotEmpty().WithMessage("El orden es obligatorio.")
                .MaximumLength(10).WithMessage("El orden no puede superar los 10 caracteres.");
        }
    }
}
