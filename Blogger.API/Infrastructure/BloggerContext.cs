using Blogger.API.Core;
using Blogger.API.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Blogger.API.Infrastructure
{
    public class BloggerContext : DbContext
    {
        public BloggerContext(DbContextOptions<BloggerContext> options)
            : base (options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Story> Stories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogConfiguration).Assembly);
        }
    }
}
