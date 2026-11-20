using FluentValidation;
using IES_CREA.API.DTOs.Academico;

namespace IES_CREA.API.Validators
{
    public class InscripcionActualizarValidator : AbstractValidator<InscripcionActualizarDto>
    {
        public InscripcionActualizarValidator()
        {
            RuleFor(x => x.IdInscripcion)
                .GreaterThan(0).WithMessage("El ID de la inscripción debe ser mayor a 0.");

            RuleFor(x => x.IdAlumno)
                .GreaterThan(0).WithMessage("El ID del alumno debe ser mayor a 0.");

            RuleFor(x => x.FechaInicio)
                .NotEmpty().WithMessage("La fecha de inicio es obligatoria.");

            RuleFor(x => x.FechaFin)
                .NotEmpty().WithMessage("La fecha de fin es obligatoria.")
                .GreaterThanOrEqualTo(x => x.FechaInicio)
                .WithMessage("La fecha de fin no puede ser anterior a la fecha de inicio.");

            RuleFor(x => x.TipoInscripcion)
                .NotEmpty().WithMessage("El tipo de inscripción es obligatorio.")
                .MaximumLength(50).WithMessage("El tipo de inscripción no puede superar los 50 caracteres.");

            RuleFor(x => x.Observacion)
                .NotEmpty().WithMessage("La observación es obligatoria.")
                .MaximumLength(500).WithMessage("La observación no puede superar los 500 caracteres.");

            // No es necesario validar 'Estado' ya que es un bool (siempre tiene valor).
        }
    }
}