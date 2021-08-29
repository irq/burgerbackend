using System;
using System.Collections.Generic;

namespace Sion.BurgerBackend.Api.Model
{
    public class GetRestaurantResponse
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public List<GetBurgerResponse> Burgers { get; private set; }

        public GetRestaurantResponse(Guid id, string name, List<GetBurgerResponse> burgers)
        {
            Id = id;
            Name = name;
            Burgers = burgers;
        }
    }
}
