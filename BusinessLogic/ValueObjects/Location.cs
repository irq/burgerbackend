using System;
using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace Sion.BurgerBackend.BusinessLogic.ValueObjects
{
    public class Location : ValueObject
    {
        public double Latitude { get; }
        public double Longitude { get; }

        protected Location()
        {
        }

        private Location(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public static Result<Location> Create(double? latitude, double? longitude)
        {
            return Result
                .SuccessIf(
                    latitude.HasValue && longitude.HasValue,
                    (latitude!.Value, longitude!.Value),
                    "Latitude and Longitude must not be empty")
                .Ensure(
                    x => ValidateLatitude(x.Item1) && ValidateLongitude(x.Item2),
                    "Location must have valid coordinates")
                .Map(x => new Location(x.Item1, x.Item2));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Latitude;
            yield return Longitude;
        }

        private static bool ValidateLongitude(double longitude)
        {
            return longitude >= -180 && longitude <= 180;
        }

        private static bool ValidateLatitude(double latitude)
        {
            return latitude >= -90 && latitude <= 90;
        }

        public double DistanceInMeters(Location location)
        {
            return GetDistance(Longitude, Latitude, location.Longitude, location.Latitude);
        }

        // https://stackoverflow.com/a/51839058/2227019
        private static double GetDistance(double longitude, double latitude, double otherLongitude, double otherLatitude)
        {
            var d1 = latitude * (Math.PI / 180.0);
            var num1 = longitude * (Math.PI / 180.0);
            var d2 = otherLatitude * (Math.PI / 180.0);
            var num2 = otherLongitude * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) + Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);

            return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
        }
    }
}
