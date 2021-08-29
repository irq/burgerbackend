using System;
using System.Collections.Generic;

namespace Sion.BurgerBackend.Api.Model
{
    public class GetBurgerResponse
    {
        public Guid Id { get; }
        public string Name { get; private set; }
        public List<GetReviewResponse> Reviews { get; private set; }

        public GetBurgerResponse(Guid id, string name, List<GetReviewResponse> reviews)
        {
            Id = id;
            Name = name;
            Reviews = reviews;
        }
    }
}
