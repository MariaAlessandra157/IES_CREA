using FluentValidation;
using IES_CREA.API.DTOs.Finanzas;

namespace IES_CREA.API.Validators
{
    public class CuotaActualizarValidator : AbstractValidator<CuotaActualizarDto>
    {
        public CuotaActualizarValidator()
        {
            RuleFor(x => x.IdCuotas)
                .GreaterThan(0).WithMessage("El ID de la cuota debe ser mayor a 0.");

            RuleFor(x => x.Monto)
                .GreaterThan(0).WithMessage("El monto debe ser mayor a 0.");

            RuleFor(x => x.FechaVencimiento)
                .NotEmpty().WithMessage("La fecha de vencimiento es obligatoria.");

            // El campo Estado es bool, no requiere validación adicional.
        }
    }
}