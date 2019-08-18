using FluentValidation;
using FluentValidation.Results;
using ShelterFinder.Domain.ViewModels;

namespace ShelterFinder.Domain.Command.Shelter
{
    public class ShelterCommand : BaseCommand
    {
        public ShelterViewModel shelter { get; set; }

        public InlineValidator<T> GetValidator<T>() where T : ShelterCommand
        {
            var validator = new InlineValidator<T>();

            //validator.RuleFor(p => p)
            //    .Custom((entity, context) =>
            //    {
            //        if (true)
            //        {
            //            context.AddFailure("Error");
            //            return;
            //        }
            //    });

            //validator.RuleFor(r => r.Id)
            //    .NotEmpty()
            //    .WithMessage("Error");

            return validator;
        }

        public ValidationResult Validate()
        {
            return GetValidator<ShelterCommand>().Validate(this);
        }
    }
}
