using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Domain.Relations;

namespace Threads.Persistence.Configurations.Relations
{
    public class RepostPostConfiguration : IEntityTypeConfiguration<RepostPost>
    {
        public void Configure (Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<RepostPost> builder)
        {
            builder.ToTable("RepostPosts");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.RepostId);

            builder.HasIndex(x => x.PostId);

            builder.Property(x => x.RepostId)
                .IsRequired(true);

            builder.Property(x => x.PostId)
                .IsRequired(true);
        }
    }
}
