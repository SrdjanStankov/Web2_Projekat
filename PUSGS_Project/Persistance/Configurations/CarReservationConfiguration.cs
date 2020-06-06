using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations
{
	public class CarReservationConfiguration : IEntityTypeConfiguration<CarReservation>
	{
		public void Configure(EntityTypeBuilder<CarReservation> builder)
		{
		}
	}
}