using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations
{
    public class RenACarAdministratorConfiguration : IEntityTypeConfiguration<RentACarAdministrator>
    {
        public void Configure(EntityTypeBuilder<RentACarAdministrator> builder)
        {

        }
    }
}
