using FluentValidation;
using IES_CREA.API.DTOs.Academico;
using System;

namespace IES_CREA.API.Validators
{
    public class ClaseCrearValidator : AbstractValidator<ClaseCrearDto>
    {
        public ClaseCrearValidator()
        {
            RuleFor(x => x.IdDocente)
                .GreaterThan(0).WithMessage("El ID del docente es obligatorio.");

            RuleFor(x => x.IdMateria)
                .GreaterThan(0).WithMessage("El ID de la materia es obligatorio.");

            RuleFor(x => x.IdAula)
                .GreaterThan(0).WithMessage("El ID del aula es obligatorio.");

            RuleFor(x => x.TipoClase)
                .NotEmpty().WithMessage("El tipo de clase es obligatorio.")
                .MaximumLength(50).WithMessage("El tipo de clase no puede superar los 50 caracteres.");

            RuleFor(x => x.Fecha)
                .NotEmpty().WithMessage("La fecha es obligatoria.")
                .Must(fecha => fecha >= DateOnly.FromDateTime(DateTime.Today))
                .WithMessage("La fecha de la clase no puede ser en el pasado.");

            RuleFor(x => x.HoraInicio)
                .NotEmpty().WithMessage("La hora de inicio es obligatoria.");

            RuleFor(x => x.HoraFinal)
                .NotEmpty().WithMessage("La hora de fin es obligatoria.")
                .GreaterThan(x => x.HoraInicio).WithMessage("La hora de finalización debe ser posterior a la hora de inicio.");

            RuleFor(x => x.Observacion)
                .NotEmpty().WithMessage("La observación es obligatoria.")
                .MaximumLength(300).WithMessage("La observación no puede superar los 300 caracteres.");
        }
    }
}
