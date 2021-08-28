using System;
using CSharpFunctionalExtensions;

namespace Sion.BurgerBackend.BusinessLogic.Entities
{
    public class Burger : Entity<Guid>
    {
        public string Name { get; private set; }

        public Burger(string name)
        {
            Name = name;
        }
    }
}
