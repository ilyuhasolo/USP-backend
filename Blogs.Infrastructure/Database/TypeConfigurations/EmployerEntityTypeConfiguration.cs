using Blogs.Core.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blogs.Infrastructure.Database.TypeConfigurations
{
    public class EmployerEntityTypeConfiguration : IEntityTypeConfiguration<Employer>
    {
        public void Configure(EntityTypeBuilder<Employer> builder)
        {
            builder.Property(x => x.Company).HasMaxLength(100);
            builder.Property(x => x.Presentation).HasMaxLength(1000);
        }
    }
}
