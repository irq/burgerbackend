using System;
using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace Sion.BurgerBackend.BusinessLogic.Entities
{
    public class Burger : Entity<Guid>
    {
        public string Name { get; private set; }
        public virtual List<Review> Reviews { get; private set; }

#pragma warning disable 8618
        // Disable null warning for non nullables missing from constructor required by efcore
        protected Burger() { }
#pragma warning restore 8618

        public Burger(string name, List<Review> reviews)
        {
            Name = name;
            Reviews = reviews;
        }
    }
}
