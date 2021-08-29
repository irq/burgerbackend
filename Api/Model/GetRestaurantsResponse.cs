using System.Collections.Generic;

namespace Sion.BurgerBackend.Api.Model
{
    public class GetRestaurantsResponse
    {
        public string Name { get; private set; }
        public List<GetBurgerResponse> Burgers { get; private set; }

        public GetRestaurantsResponse(string name, List<GetBurgerResponse> burgers)
        {
            Name = name;
            Burgers = burgers;
        }
    }
}
