using FluentValidation;
using IES_CREA.API.DTOs.Persona;

namespace IES_CREA.API.Validators
{
    public class PersonaActualizarValidator : AbstractValidator<PersonaActualizarDto>
    {
        public PersonaActualizarValidator()
        {
            RuleFor(x => x.IdPersona)
                .GreaterThan(0).WithMessage("El ID de la persona debe ser mayor a 0.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede superar los 100 caracteres.");

            RuleFor(x => x.Apellido)
                .NotEmpty().WithMessage("El apellido es obligatorio.")
                .MaximumLength(100).WithMessage("El apellido no puede superar los 100 caracteres.");

            // El DNI en este DTO es opcional (string?), validamos longitud si se envía
            RuleFor(x => x.Dni)
                .MaximumLength(20).WithMessage("El DNI no puede superar los 20 caracteres.");

            // La FechaNacimiento es opcional (DateOnly?)
            RuleFor(x => x.FechaNacimiento)
                .NotEmpty().WithMessage("La fecha de nacimiento no puede ser nula si se envía.");

            RuleFor(x => x.Telefono)
                .MaximumLength(20).WithMessage("El teléfono no puede superar los 20 caracteres.");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("El formato del correo electrónico no es válido.")
                .MaximumLength(100).WithMessage("El correo no puede superar los 100 caracteres.");

            RuleFor(x => x.Direccion)
                .MaximumLength(200).WithMessage("La dirección no puede superar los 200 caracteres.");
        }
    }
}
