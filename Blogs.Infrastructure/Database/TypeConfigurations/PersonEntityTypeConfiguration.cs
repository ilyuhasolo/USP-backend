using Blogs.Core.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blogs.Infrastructure.Database.TypeConfigurations
{
    public class PersonEntityTypeConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(30);
            builder.Property(x => x.Password).HasMaxLength(70);
            builder.Property(x => x.PhoneNumber).HasMaxLength(12);
            builder.Property(x => x.Email).HasMaxLength(30);

            builder
                .HasMany(x => x.Interests)
                .WithMany(x => x.People);
            builder
                .HasMany(x => x.Roles)
                .WithMany(x => x.People);
            builder
                .HasMany(x => x.Teams)
                .WithMany(x => x.People)
                .UsingEntity<Lineup>(
                x => x
                    .HasOne(pt => pt.Team)
                    .WithMany(t => t.Lineups)
                    .HasForeignKey(pt => pt.TeamId),
                x => x
                    .HasOne(pt => pt.Person)
                    .WithMany(t => t.Lineups)
                    .HasForeignKey(pt => pt.PersonId),
                x =>
                {
                    x.HasKey(t => new { t.PersonId, t.TeamId });
                    x.ToTable("Lineups");
                });

            builder
                .HasOne(x => x.Student)
                .WithOne(x => x.Person)
                .HasForeignKey<Student>(x => x.PersonId);
            builder
                .HasOne(x => x.Teacher)
                .WithOne(x => x.Person)
                .HasForeignKey<Teacher>(x => x.PersonId);
            builder
                .HasOne(x => x.Employer)
                .WithOne(x => x.Person)
                .HasForeignKey<Employer>(x => x.PersonId);
        }
    }
}
