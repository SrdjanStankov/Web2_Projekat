using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public DbSet<User> User { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<Flight> Flight { get; set; }
        public DbSet<FlightSeat> FlightSeats { get; set; }
        public DbSet<FlightTicket> FlightTicket { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<RentACar> RentACar { get; set; }
        public DbSet<AviationCompany> AviationCompany { get; set; }
    }
}