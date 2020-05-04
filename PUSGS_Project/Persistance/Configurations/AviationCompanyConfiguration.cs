using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations
{
    public class AviationCompanyConfiguration : IEntityTypeConfiguration<AviationCompany>
    {
        public void Configure(EntityTypeBuilder<AviationCompany> builder)
        {
        }
    }
}