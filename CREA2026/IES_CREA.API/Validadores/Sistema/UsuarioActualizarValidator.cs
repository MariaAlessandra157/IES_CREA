using FluentValidation;
using IES_CREA.API.DTOs.Sistema;

namespace IES_CREA.API.Validators
{
    public class UsuarioActualizarValidator : AbstractValidator<UsuarioActualizarDto>
    {
        public UsuarioActualizarValidator()
        {
            RuleFor(x => x.IdUsuario)
                .GreaterThan(0).WithMessage("El ID del usuario debe ser mayor a 0.");

            RuleFor(x => x.NombreUsuario)
                .NotEmpty().WithMessage("El nombre de usuario es obligatorio.")
                .Length(4, 50).WithMessage("El nombre de usuario debe tener entre 4 y 50 caracteres.");

            // La contraseña es opcional, solo se valida si se envió
            RuleFor(x => x.Password)
                .MinimumLength(6).WithMessage("La contraseña debe tener al menos 6 caracteres.")
                .MaximumLength(100).WithMessage("La contraseña no puede superar los 100 caracteres.")
                .When(x => !string.IsNullOrEmpty(x.Password));
        }
    }
}