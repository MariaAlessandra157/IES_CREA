using FluentValidation;
using IES_CREA.API.DTOs.Academico;

namespace IES_CREA.API.Validators
{
    public class TrayectoriaValidator : AbstractValidator<TrayectoriaDto>
    {
        public TrayectoriaValidator()
        {
            RuleFor(x => x.IdTrayectoria)
                .GreaterThan(0).WithMessage("El ID de la trayectoria debe ser mayor a 0.");

            RuleFor(x => x.IdAlumno)
                .GreaterThan(0).WithMessage("El ID del alumno es obligatorio.");

            RuleFor(x => x.IdInstitucion)
                .GreaterThan(0).WithMessage("El ID de la institución es obligatorio.");

            RuleFor(x => x.IdCurso)
                .GreaterThan(0).WithMessage("El ID del curso es obligatorio.");

            RuleFor(x => x.Division)
                .NotEmpty().WithMessage("La división es obligatoria.")
                .MaximumLength(20).WithMessage("La división no puede superar los 20 caracteres.");

            RuleFor(x => x.Ciclolectivo)
                .NotEmpty().WithMessage("El ciclo lectivo es obligatorio.")
                .Length(4).WithMessage("El ciclo lectivo debe tener exactamente 4 caracteres.");

            RuleFor(x => x.FechaDesde)
                .NotEmpty().WithMessage("La fecha desde es obligatoria.");

            RuleFor(x => x.FechaHasta)
                .NotEmpty().WithMessage("La fecha hasta es obligatoria.")
                .GreaterThanOrEqualTo(x => x.FechaDesde)
                .WithMessage("La fecha hasta no puede ser anterior a la fecha desde.");

            RuleFor(x => x.Observaciones)
                .NotEmpty().WithMessage("Las observaciones son obligatorias.")
                .MaximumLength(200).WithMessage("Las observaciones no pueden superar los 200 caracteres.");
        }
    }
}