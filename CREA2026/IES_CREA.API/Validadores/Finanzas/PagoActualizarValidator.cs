using FluentValidation;
using IES_CREA.API.DTOs.Finanzas;

namespace IES_CREA.API.Validators
{
    public class PagoActualizarValidator : AbstractValidator<PagoActualizarDto>
    {
        public PagoActualizarValidator()
        {
            RuleFor(x => x.IdPago)
                .GreaterThan(0).WithMessage("El ID del pago debe ser mayor a 0.");

            RuleFor(x => x.IdCuota)
                .GreaterThan(0).WithMessage("El ID de la cuota es obligatorio.");

            RuleFor(x => x.IdPersonal)
                .GreaterThan(0).WithMessage("El ID del personal es obligatorio.");

            RuleFor(x => x.FechaPago)
                .NotEmpty().WithMessage("La fecha de pago es obligatoria.");

            RuleFor(x => x.Monto)
                .GreaterThan(0).WithMessage("El monto debe ser mayor a 0.");

            RuleFor(x => x.MedioPago)
                .NotEmpty().WithMessage("El medio de pago es obligatorio.")
                .MaximumLength(50).WithMessage("El medio de pago no puede superar los 50 caracteres.");

            RuleFor(x => x.Observacion)
                .NotEmpty().WithMessage("La observación es obligatoria.")
                .MaximumLength(300).WithMessage("La observación no puede superar los 300 caracteres.");
        }
    }
}