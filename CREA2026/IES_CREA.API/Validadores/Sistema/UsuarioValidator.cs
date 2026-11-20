using FluentValidation;
using IES_CREA.API.DTOs.Sistema;

namespace IES_CREA.API.Validators
{
    public class UsuarioValidator : AbstractValidator<UsuarioDto>
    {
        public UsuarioValidator()
        {
            RuleFor(x => x.IdUsuario)
                .GreaterThan(0).WithMessage("El ID del usuario debe ser mayor a 0.");

            RuleFor(x => x.IdPersona)
                .GreaterThan(0).WithMessage("El ID de la persona es obligatorio.");

            RuleFor(x => x.NombreUsuario)
                .NotEmpty().WithMessage("El nombre de usuario es obligatorio.")
                .Length(4, 50).WithMessage("El nombre de usuario debe tener entre 4 y 50 caracteres.");
        }
    }
}