using FluentValidation;
using IES_CREA.API.DTOs.Persona;
using System;

namespace IES_CREA.API.Validators
{
    public class AlumnoCrearValidator : AbstractValidator<AlumnoCrearDto>
    {
        public AlumnoCrearValidator()
        {
            RuleFor(x => x.IdPersona)
                .GreaterThan(0).WithMessage("El ID de la persona es obligatorio y debe ser mayor a 0.");

            RuleFor(x => x.FechaIngreso)
                .NotEmpty().WithMessage("La fecha de ingreso es obligatoria.");

            RuleFor(x => x.FechaEgreso)
                .NotEmpty().WithMessage("La fecha de egreso es obligatoria.")
                .GreaterThanOrEqualTo(x => x.FechaIngreso)
                .WithMessage("La fecha de egreso no puede ser anterior a la fecha de ingreso.");

            RuleFor(x => x.Observaciones)
                .NotEmpty().WithMessage("La observación es obligatoria.")
                .MaximumLength(300).WithMessage("La observación no puede superar los 300 caracteres.");
        }
    }
}
