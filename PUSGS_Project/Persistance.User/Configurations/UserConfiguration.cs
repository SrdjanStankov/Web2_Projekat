using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.User.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<Core.Entities.User>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.User> builder)
        {
            builder.HasKey(u => u.Email);
            builder.HasDiscriminator<string>("Discriminator")
                .HasValue<AviationAdministrator>(nameof(AviationAdministrator))
                .HasValue<Core.Entities.User>(nameof(Core.Entities.User))
                .HasValue<RentACarAdministrator>(nameof(RentACarAdministrator))
                .HasValue<SystemAdministrator>(nameof(SystemAdministrator));
        }
    }
}
