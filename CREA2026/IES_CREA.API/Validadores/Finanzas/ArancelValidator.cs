using FluentValidation;
using IES_CREA.API.DTOs.Finanzas;

namespace IES_CREA.API.Validators
{
    public class ArancelValidator : AbstractValidator<ArancelDto>
    {
        public ArancelValidator()
        {
            RuleFor(x => x.IdArancel)
                .GreaterThan(0).WithMessage("El ID del arancel debe ser mayor a 0.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre del arancel es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede superar los 50 caracteres.");

            RuleFor(x => x.Descripcion)
                .NotEmpty().WithMessage("La descripción es obligatoria.")
                .MaximumLength(300).WithMessage("La descripción no puede superar los 300 caracteres.");

            RuleFor(x => x.Monto)
                .GreaterThan(0).WithMessage("El monto debe ser mayor a 0.");

            RuleFor(x => x.FechaVigenciaDesde)
                .NotEmpty().WithMessage("La fecha de vigencia desde es obligatoria.");

            RuleFor(x => x.FechaVigenciaHasta)
                .NotEmpty().WithMessage("La fecha de vigencia hasta es obligatoria.")
                .GreaterThanOrEqualTo(x => x.FechaVigenciaDesde)
                .WithMessage("La fecha de vigencia hasta no puede ser anterior a la fecha de vigencia desde.");
        }
    }
}