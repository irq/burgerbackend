using System;
using CSharpFunctionalExtensions;
using Sion.BurgerBackend.BusinessLogic.ValueObjects;

namespace Sion.BurgerBackend.BusinessLogic.Entities
{
    public class Review : Entity<Guid>
    {
        public virtual User User { get; private set; }
        public virtual Burger Burger { get; private set; }
        public Rating TasteScore { get; private set; }
        public Rating TextureScore { get; private set; }
        public Rating VisualScore { get; private set; }

#pragma warning disable 8618
        // Disable null warning for non nullables missing from constructor required by efcore
        protected Review() { }
#pragma warning restore 8618

        public Review(User user, Burger burger, Rating tasteScore, Rating textureScore, Rating visualScore)
        {
            User = user;
            Burger = burger;
            TasteScore = tasteScore;
            TextureScore = textureScore;
            VisualScore = visualScore;
        }
    }
}
