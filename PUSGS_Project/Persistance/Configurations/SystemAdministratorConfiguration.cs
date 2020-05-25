using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations
{
    public class SystemAdministratorConfiguration : IEntityTypeConfiguration<SystemAdministrator>
    {
        public void Configure(EntityTypeBuilder<SystemAdministrator> builder)
        {

        }
    }
}
