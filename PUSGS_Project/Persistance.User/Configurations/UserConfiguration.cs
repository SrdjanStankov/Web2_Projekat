using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.User.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<Core.Entities.User>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.User> builder) => builder.HasKey(u => u.Email);
    }
}
