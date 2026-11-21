using FluentValidation;
using IES_CREA.API.DTOs.Persona;

namespace IES_CREA.API.Validators
{
    public class ResponsableActualizarValidator : AbstractValidator<ResponsableActualizarDto>
    {
        public ResponsableActualizarValidator()
        {
            RuleFor(x => x.IdResponsable)
                .GreaterThan(0).WithMessage("El ID del responsable debe ser mayor a 0.");

            RuleFor(x => x.IdPersona)
                .GreaterThan(0).WithMessage("El ID de la persona es obligatorio.");
        }
    }
}