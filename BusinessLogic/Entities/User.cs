using System;
using CSharpFunctionalExtensions;
using Sion.BurgerBackend.BusinessLogic.ValueObjects;

namespace Sion.BurgerBackend.BusinessLogic.Entities
{
    public class User : Entity<Guid>
    {
        public Username Username { get; private set; }

        public User(Username username)
        {
            Username = username;
        }
    }
}
