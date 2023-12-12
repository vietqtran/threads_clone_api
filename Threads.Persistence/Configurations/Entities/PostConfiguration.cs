using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Domain.Entities;

namespace Threads.Persistence.Configurations.Entities
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure (EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("_Posts");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                .IsRequired();
        }
    }
}
