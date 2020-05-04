using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations
{
    public class FlightTicketConfiguration : IEntityTypeConfiguration<FlightTicket>
    {
        public void Configure(EntityTypeBuilder<FlightTicket> builder)
        {
        }
    }
}