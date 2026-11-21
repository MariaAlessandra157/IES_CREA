using FluentValidation;
using IES_CREA.API.DTOs.Academico;

namespace IES_CREA.API.Validators.Academico
{
    public class MateriaValidator : AbstractValidator<MateriaDto>
    {
        public MateriaValidator()
        {
            RuleFor(x => x.IdMateria)
                .GreaterThan(0).WithMessage("El ID de la materia debe ser mayor a 0.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre de la materia es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede superar los 100 caracteres.");

            RuleFor(x => x.Descripcion)
                .MaximumLength(300).WithMessage("La descripción no puede superar los 300 caracteres.");
        }
    }
}
