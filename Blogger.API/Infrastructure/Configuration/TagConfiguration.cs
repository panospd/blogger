using Blogger.API.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.API.Infrastructure.Configuration
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasOne(t => t.Story)
                .WithMany(s => s.Tags)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(t => t.Name).IsRequired();
        }
    }
}
