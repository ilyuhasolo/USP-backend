using Blogs.Core.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Infrastructure.Database
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
