using FluentValidation;
using IES_CREA.API.DTOs.Persona;

namespace IES_CREA.API.Validators
{
    public class DocenteActualizarValidator : AbstractValidator<DocenteActualizarDto>
    {
        public DocenteActualizarValidator()
        {
            RuleFor(x => x.IdDocente)
                .GreaterThan(0).WithMessage("El ID del docente debe ser mayor a 0.");

            RuleFor(x => x.Especialidad)
                .NotEmpty().WithMessage("La especialidad es obligatoria.")
                .MaximumLength(100).WithMessage("La especialidad no puede superar los 100 caracteres.");

            // El campo Activo es un bool, no requiere validación adicional.
        }
    }
}