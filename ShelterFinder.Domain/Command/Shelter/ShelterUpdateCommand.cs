using FluentValidation;
using FluentValidation.Results;

namespace ShelterFinder.Domain.Command.Shelter
{
    public class ShelterUpdateCommand : ShelterBaseCommand
    {
        public InlineValidator<T> GetValidator<T>() where T : ShelterUpdateCommand
        {
            var validator = new InlineValidator<T>();

            validator.RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("The field name must have a value.");

            validator.RuleFor(p => p.Address)
                .NotEmpty()
                .WithMessage("The field address must have a value.");

            validator.RuleFor(p => p.Phone)
                .NotEmpty()
                .WithMessage("The field phone must have a value.");

            validator.RuleFor(p => p.Gender)
                .NotEmpty()
                .WithMessage("The field gender must have a value.");

            validator.RuleFor(p => p.Latitude)
                .NotEmpty()
                .WithMessage("The field latitude must have a value.");

            validator.RuleFor(p => p.Longitude)
                .NotEmpty()
                .WithMessage("The field longitude must have a value.");

            //validator.RuleFor(p => p)
            //    .Custom((entity, context) =>
            //    {
            //        if (true)
            //        {
            //            context.AddFailure("Error");
            //            return;
            //        }
            //    });

            return validator;
        }

        public ValidationResult Validate()
        {
            return GetValidator<ShelterUpdateCommand>().Validate(this);
        }
    }
}
