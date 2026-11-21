using FluentValidation;
using IES_CREA.API.DTOs.Sistema;

namespace IES_CREA.API.Validators
{
    public class RolActualizarValidator : AbstractValidator<RolActualizarDto>
    {
        public RolActualizarValidator()
        {
            RuleFor(x => x.IdRol)
                .GreaterThan(0).WithMessage("El ID del rol debe ser mayor a 0.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre del rol es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede superar los 50 caracteres.");

            RuleFor(x => x.Descripcion)
                .NotEmpty().WithMessage("La descripción es obligatoria.")
                .MaximumLength(255).WithMessage("La descripción no puede superar los 255 caracteres.");
        }
    }
}