using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Avio
{
    public class AvioDbContext : DbContext
    {
        public AvioDbContext(DbContextOptions<AvioDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(typeof(AvioDbContext).Assembly);

        public DbSet<Flight> Flights { get; set; }
        public DbSet<FlightSeat> FlightSeats { get; set; }
        public DbSet<FlightTicket> FlightTickets { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<AviationCompany> AviationCompanies { get; set; }
    }
}
