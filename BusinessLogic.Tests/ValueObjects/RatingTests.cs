using FluentAssertions;
using Sion.BurgerBackend.BusinessLogic.ValueObjects;
using Xunit;

namespace Sion.BurgerBackend.BusinessLogic.Tests.ValueObjects
{
    public class RatingTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void Create_WithValidRating_Succeeds(int rating)
        {
            Rating.Create(rating).IsSuccess.Should().BeTrue();
        }

        [Theory]
        [InlineData(-100)]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(6)]
        [InlineData(100)]
        public void Create_WithInvalidRating_Fails(int rating)
        {
            Rating.Create(rating).IsSuccess.Should().BeFalse();
        }
    }
}
