using Blogger.API.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blogger.API.Infrastructure.Configuration
{
    public class StoryConfiguration : IEntityTypeConfiguration<Story>
    {
        public void Configure(EntityTypeBuilder<Story> builder)
        {
            builder.Property(s => s.Title)
                 .IsRequired();

            builder.Property(s => s.Message)
                .IsRequired();
        }
    }
}
