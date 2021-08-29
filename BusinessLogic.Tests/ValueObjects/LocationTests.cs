using System;
using FluentAssertions;
using Sion.BurgerBackend.BusinessLogic.ValueObjects;
using Xunit;

namespace Sion.BurgerBackend.BusinessLogic.Tests.ValueObjects
{
    public class LocationTests
    {
        [Theory]
        [InlineData(-90, 1)]
        [InlineData(90, 1)]
        [InlineData(1, 1)]
        [InlineData(1, -180)]
        [InlineData(1, 180)]
        public void Create_WithValidLocation_Succeeds(double latitude, double longitude)
        {
            Location.Create(latitude, longitude).IsSuccess.Should().BeTrue();
        }

        [Theory]
        [InlineData(-90.1, 1)]
        [InlineData(90.1, 1)]
        [InlineData(1, -180.1)]
        [InlineData(1, 180.1)]
        public void Create_WithInvalidLocation_Fails(double latitude, double longitude)
        {
            Location.Create(latitude, longitude).IsSuccess.Should().BeFalse();
        }

        [Theory]
        [InlineData(55.824893, 12.203493, 25353.34)]
        [InlineData(55.926586, 12.503065, 42595.99)]
        public void DistanceInMeters_DifferentLocations_CorrectlyCalculateDistance(double latitude, double longitude, double expectedDistance)
        {
            var mainLocation = Location.Create(55.598989, 12.151273).Value;
            var otherLocation = Location.Create(latitude, longitude).Value;

            var distanceRounded = Math.Round(mainLocation.DistanceInMeters(otherLocation), 2);
            distanceRounded.Should().Be(expectedDistance);
        }
    }
}
