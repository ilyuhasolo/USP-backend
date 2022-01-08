using Blogs.Core.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blogs.Infrastructure.Database.TypeConfigurations
{
    public class InterestEntityTypeConfiguration : IEntityTypeConfiguration<Interest>
    {
        public void Configure(EntityTypeBuilder<Interest> builder)
        {
            builder.Property(x => x.InterestName).HasMaxLength(30);
        }
    }
}
