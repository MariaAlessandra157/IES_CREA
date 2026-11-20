using FluentValidation;
using IES_CREA.API.DTOs.Academico;

namespace IES_CREA.API.Validators.Academico
{
    public class MateriaCrearValidator : AbstractValidator<MateriaCrearDto>
    {
        public MateriaCrearValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre de la materia es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede superar los 100 caracteres.");

            // La descripción es opcional (es string?), así que solo validamos la longitud máxima
            RuleFor(x => x.Descripcion)
                .MaximumLength(300).WithMessage("La descripción no puede superar los 300 caracteres.");
        }
    }
}