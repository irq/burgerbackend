using System.Collections.Generic;

namespace Sion.BurgerBackend.Api.Model
{
    public class GetRestaurantsResponse
    {
        public List<GetBurgerResponse> Burgers { get; private set; }

        public GetRestaurantsResponse(List<GetBurgerResponse> burgers)
        {
            Burgers = burgers;
        }
    }
}
