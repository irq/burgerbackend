using System.Collections.Generic;
using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace Sion.BurgerBackend.BusinessLogic.ValueObjects
{
    public class Username : ValueObject
    {
        public string Value { get; }

        private Username(string value)
        {
            Value = value;
        }

        public static Result<Username> Create(string? username)
        {
            return Result.SuccessIf(username != null, username!, "Username should not be null")
                .Map(x => x.Trim())
                .Ensure(x => x.Length > 0, "Username should not be empty")
                .Ensure(x => Regex.IsMatch(x, "^[\\w]{5,20}$"), "Username is in invalid format")
                .Map(x => new Username(x));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value.ToLowerInvariant();
        }

        public static explicit operator Username(string username)
        {
            return Create(username).Value;
        }

        public static implicit operator string(Username username)
        {
            return username.Value;
        }
    }
}
