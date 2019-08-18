using FluentValidation;
using FluentValidation.Results;

namespace ShelterFinder.Domain.Command.Shelter
{
    public class ShelterDeleteCommand : ShelterBaseCommand
    {
        public InlineValidator<T> GetValidator<T>() where T : ShelterDeleteCommand
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

            return validator;
        }

        public ValidationResult Validate()
        {
            return GetValidator<ShelterDeleteCommand>().Validate(this);
        }
    }
}
