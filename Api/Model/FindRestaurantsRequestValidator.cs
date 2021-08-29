using FluentValidation;
using Sion.BurgerBackend.BusinessLogic.ValueObjects;

namespace Sion.BurgerBackend.Api.Model
{
    public class FindRestaurantsRequestValidator : AbstractValidator<FindRestaurantsRequest>
    {
        public FindRestaurantsRequestValidator()
        {
            RuleFor(x => x.Latitude).ValueObjectMustValidate((x) => Location.Create(x, 1));
            RuleFor(x => x.Longitude).ValueObjectMustValidate((x) => Location.Create(1, x));
        }
    }
}
