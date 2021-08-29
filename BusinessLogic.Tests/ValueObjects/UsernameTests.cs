using FluentAssertions;
using Sion.BurgerBackend.BusinessLogic.ValueObjects;
using Xunit;

namespace Sion.BurgerBackend.BusinessLogic.Tests.ValueObjects
{
    public class UsernameTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("\n")]
        public void Create_WithWhiteSpaceOrEmpty_ShouldFail(string username)
        {
            Username.Create(username).IsSuccess.Should().BeFalse();
        }

        [Theory]
        [InlineData("valuetoolongforusername")]
        [InlineData("some")]
        [InlineData("some%username")]
        public void Create_InvalidUsernameFormats_ShouldFail(string username)
        {
            Username.Create(username).IsSuccess.Should().BeFalse();
        }

        [Theory]
        [InlineData("someusername")]
        [InlineData("some_username")]
        [InlineData("some_usernæme")]
        public void Create_Valid_ShouldSucceed(string username)
        {
            Username.Create(username).IsSuccess.Should().BeTrue();
        }
    }
}
