using FluentValidation;
using IES_CREA.API.DTOs.Finanzas;

namespace IES_CREA.API.Validators
{
    public class CuotaValidator : AbstractValidator<CuotaDto>
    {
        public CuotaValidator()
        {
            RuleFor(x => x.IdCuotas)
                .GreaterThan(0).WithMessage("El ID de la cuota debe ser mayor a 0.");

            RuleFor(x => x.IdArancel)
                .GreaterThan(0).WithMessage("El ID del arancel es obligatorio.");

            RuleFor(x => x.IdInscripcion)
                .GreaterThan(0).WithMessage("El ID de la inscripción es obligatorio.");

            RuleFor(x => x.Periodo)
                .NotEmpty().WithMessage("El período es obligatorio.")
                .MaximumLength(50).WithMessage("El período no puede superar los 50 caracteres.");

            RuleFor(x => x.Monto)
                .GreaterThan(0).WithMessage("El monto debe ser mayor a 0.");

            RuleFor(x => x.FechaVencimiento)
                .NotEmpty().WithMessage("La fecha de vencimiento es obligatoria.");
        }
    }
}
