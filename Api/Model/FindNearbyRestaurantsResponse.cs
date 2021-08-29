using System;

namespace Sion.BurgerBackend.Api.Model
{
    public class FindNearbyRestaurantsResponse
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public double DistanceInMeters { get; private set; }

        public FindNearbyRestaurantsResponse(Guid id, string name, string address, double distanceInMeters)
        {
            Id = id;
            Name = name;
            Address = address;
            DistanceInMeters = distanceInMeters;
        }
    }
}
