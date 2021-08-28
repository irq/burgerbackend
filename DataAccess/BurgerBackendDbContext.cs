using Microsoft.EntityFrameworkCore;
using Sion.BurgerBackend.BusinessLogic.Entities;

namespace Sion.BurgerBackend.DataAccess
{
    public class BurgerBackendDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants => Set<Restaurant>();
        public DbSet<Burger> Burgers => Set<Burger>();

        public BurgerBackendDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
