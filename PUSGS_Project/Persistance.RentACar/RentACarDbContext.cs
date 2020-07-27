using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistance.RentACar
{
    public class RentACarDbContext : DbContext
    {
        public RentACarDbContext(DbContextOptions<RentACarDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(typeof(RentACarDbContext).Assembly);

        public DbSet<Car> Cars { get; set; }
        public DbSet<Core.Entities.RentACar> RentACars { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<CarReservation> CarReservations { get; set; }
        public DbSet<Rating> Ratings { get; set; }
    }
}
