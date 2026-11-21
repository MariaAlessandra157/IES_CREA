using FluentValidation;
using IES_CREA.API.DTOs.Academico;

namespace IES_CREA.API.Validators
{
    public class SeguimientoActualizarValidator : AbstractValidator<SeguimientoActualizarDto>
    {
        public SeguimientoActualizarValidator()
        {
            RuleFor(x => x.IdSeguimiento)
                .GreaterThan(0).WithMessage("El ID del seguimiento debe ser mayor a 0.");

            RuleFor(x => x.TemaTrabajado)
                .NotEmpty().WithMessage("El tema trabajado es obligatorio.")
                .MaximumLength(300).WithMessage("El tema trabajado no puede superar los 300 caracteres.");

            RuleFor(x => x.Avance)
                .NotEmpty().WithMessage("El avance es obligatorio.")
                .MaximumLength(300).WithMessage("El avance no puede superar los 300 caracteres.");

            RuleFor(x => x.Dificultades)
                .NotEmpty().WithMessage("Las dificultades son obligatorias.")
                .MaximumLength(300).WithMessage("Las dificultades no pueden superar los 300 caracteres.");

            RuleFor(x => x.Recomendaciones)
                .NotEmpty().WithMessage("Las recomendaciones son obligatorias.")
                .MaximumLength(300).WithMessage("Las recomendaciones no pueden superar los 300 caracteres.");

            RuleFor(x => x.Observaciones)
                .NotEmpty().WithMessage("Las observaciones son obligatorias.")
                .MaximumLength(300).WithMessage("Las observaciones no pueden superar los 300 caracteres.");
        }
    }
}
