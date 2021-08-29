using System;
using System.Collections.Generic;
using CSharpFunctionalExtensions;
using Sion.BurgerBackend.BusinessLogic.ValueObjects;

namespace Sion.BurgerBackend.BusinessLogic.Entities
{
    public class Restaurant : Entity<Guid>
    {
        public string Name { get; private set; }
        public string Address { get; private set; }
        public Location Location { get; private set; }
        public virtual List<Burger> Burgers { get; private set; }

#pragma warning disable 8618
        // Disable null warning for non nullables missing from constructor required by efcore
        protected Restaurant() { }
#pragma warning restore 8618

        public Restaurant(string name, string address, Location location, List<Burger> burgers)
        {
            Address = address;
            Name = name;
            Burgers = burgers;
            Location = location;
        }
    }
}
