using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations
{
    public class RentACarConfiguration : IEntityTypeConfiguration<RentACar>
    {
        public void Configure(EntityTypeBuilder<RentACar> builder)
        {
        }
    }
}