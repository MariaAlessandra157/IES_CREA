using FluentValidation;
using IES_CREA.API.DTOs.Persona;

namespace IES_CREA.API.Validators
{
    public class AlumnoValidator : AbstractValidator<AlumnoDto>
    {
        public AlumnoValidator()
        {
            RuleFor(x => x.IdAlumno)
                .GreaterThan(0).WithMessage("El ID del alumno debe ser mayor a 0.");

            RuleFor(x => x.IdPersona)
                .GreaterThan(0).WithMessage("El ID de la persona debe ser mayor a 0.");

            RuleFor(x => x.Observaciones)
                .NotEmpty().WithMessage("La observación es obligatoria.")
                .MaximumLength(300).WithMessage("La observación no puede superar los 300 caracteres.");
        }
    }
}