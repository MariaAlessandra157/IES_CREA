using FluentValidation;
using IES_CREA.API.DTOs.Sistema;

namespace IES_CREA.API.Validators
{
    public class UsuarioCrearValidator : AbstractValidator<UsuarioCrearDto>
    {
        public UsuarioCrearValidator()
        {
            RuleFor(x => x.IdPersona)
                .GreaterThan(0).WithMessage("El ID de la persona es obligatorio.");

            RuleFor(x => x.NombreUsuario)
                .NotEmpty().WithMessage("El nombre de usuario es obligatorio.")
                .Length(4, 50).WithMessage("El nombre de usuario debe tener entre 4 y 50 caracteres.")
                .Matches(@"^[a-zA-Z0-9._-]+$").WithMessage("El nombre de usuario solo puede contener letras, números, puntos, guiones bajos y guiones.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("La contraseña es obligatoria.")
                .MinimumLength(6).WithMessage("La contraseña debe tener al menos 6 caracteres.")
                .MaximumLength(100).WithMessage("La contraseña no puede superar los 100 caracteres.");
        }
    }
}