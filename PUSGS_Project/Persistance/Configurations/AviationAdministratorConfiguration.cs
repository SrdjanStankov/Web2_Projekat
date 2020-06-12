using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations
{

    public class AviationAdministratorConfiguration : IEntityTypeConfiguration<AviationAdministrator>
    {
        public void Configure(EntityTypeBuilder<AviationAdministrator> builder)
        {
        }
    }
}