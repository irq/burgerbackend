using System;

namespace Sion.BurgerBackend.Api.Model
{
    public class GetBurgerResponse
    {
        public Guid Id { get; }
        public string Name { get; private set; }

        public GetBurgerResponse(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
