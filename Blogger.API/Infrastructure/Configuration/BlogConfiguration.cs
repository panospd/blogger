using Blogger.API.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blogger.API.Infrastructure.Configuration
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(b => b.Id);
        }
    }
}
