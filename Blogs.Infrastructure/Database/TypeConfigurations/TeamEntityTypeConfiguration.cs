using Blogs.Core.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blogs.Infrastructure.Database.TypeConfigurations
{
    public class TeamEntityTypeConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(30);
            builder.Property(x => x.Description).HasMaxLength(3999);

            builder
                .HasMany(x => x.Interests)
                .WithMany(x => x.Teams);
            builder
                .HasMany(x => x.Roles)
                .WithMany(x => x.Teams);
        }
    }
}
