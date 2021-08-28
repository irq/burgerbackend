namespace Sion.BurgerBackend.Api.Model
{
    public class GetBurgerResponse
    {
        public string Name { get; private set; }

        public GetBurgerResponse(string name)
        {
            Name = name;
        }
    }
}
