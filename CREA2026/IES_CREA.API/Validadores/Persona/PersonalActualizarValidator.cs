using FluentValidation;
using IES_CREA.API.DTOs.Persona;

namespace IES_CREA.API.Validators
{
    public class PersonalActualizarValidator : AbstractValidator<PersonalActualizarDto>
    {
        public PersonalActualizarValidator()
        {
            RuleFor(x => x.IdPersonal)
                .GreaterThan(0).WithMessage("El ID del personal debe ser mayor a 0.");

            RuleFor(x => x.IdPersona)
                .GreaterThan(0).WithMessage("El ID de la persona es obligatorio.");

            RuleFor(x => x.IdCargo)
                .GreaterThan(0).WithMessage("El ID del cargo es obligatorio.");

            RuleFor(x => x.FechaIngreso)
                .NotEmpty().WithMessage("La fecha de ingreso es obligatoria.");

            // El campo Activo no requiere validación adicional al ser bool.
        }
    }
}
