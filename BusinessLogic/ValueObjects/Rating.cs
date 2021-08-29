using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace Sion.BurgerBackend.BusinessLogic.ValueObjects
{
    public class Rating : ValueObject
    {
        public int Value { get; }

        private Rating(int value)
        {
            Value = value;
        }

        public static Result<Rating> Create(int rating)
        {
            return Result
                .SuccessIf(rating > 0 && rating <= 5, rating, "Rating should be an integer between 1 and 5")
                .Map(x => new Rating(x));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static explicit operator Rating(int rating)
        {
            return Create(rating).Value;
        }

        public static implicit operator int(Rating rating)
        {
            return rating.Value;
        }
    }
}
