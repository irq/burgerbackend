using Microsoft.EntityFrameworkCore;
using Sion.BurgerBackend.BusinessLogic.Entities;
using Sion.BurgerBackend.BusinessLogic.ValueObjects;

namespace Sion.BurgerBackend.DataAccess
{
    public class BurgerBackendDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants => Set<Restaurant>();
        public DbSet<Burger> Burgers => Set<Burger>();
        public DbSet<Review> Reviews => Set<Review>();
        public DbSet<User> Users => Set<User>();

        public BurgerBackendDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>(x =>
            {
                x.OwnsOne(p => p.Location, p =>
                {
                    p.Property(pp => pp.Latitude);
                    p.Property(pp => pp.Longitude);
                });
            });

            modelBuilder.Entity<User>(x =>
            {
                x.Property(p => p.Username).HasConversion(p => p.Value, p => (Username)p);
            });

            modelBuilder.Entity<Review>(x =>
            {
                x.Property(p => p.TasteScore).HasConversion(p => p.Value, p => (Rating)p);
                x.Property(p => p.VisualScore).HasConversion(p => p.Value, p => (Rating)p);
                x.Property(p => p.TextureScore).HasConversion(p => p.Value, p => (Rating)p);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
