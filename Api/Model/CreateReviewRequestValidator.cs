using FluentValidation;
using Sion.BurgerBackend.BusinessLogic.ValueObjects;

namespace Sion.BurgerBackend.Api.Model
{
    public class CreateReviewRequestValidator : AbstractValidator<CreateReviewRequest>
    {
        public CreateReviewRequestValidator()
        {
            RuleFor(x => x.Username).ValueObjectMustValidate((x) => Username.Create(x));
            RuleFor(x => x.BurgerId).NotEmpty();
            RuleFor(x => x.TasteScore).ValueObjectMustValidate((x) => Rating.Create(x));
            RuleFor(x => x.TextureScore).ValueObjectMustValidate((x) => Rating.Create(x));
            RuleFor(x => x.VisualScore).ValueObjectMustValidate((x) => Rating.Create(x));
        }
    }
}
