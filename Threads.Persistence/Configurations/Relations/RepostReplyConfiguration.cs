using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Domain.Relations;

namespace Threads.Persistence.Configurations.Relations
{
    public class RepostReplyConfiguration : IEntityTypeConfiguration<RepostReply>
    {
        public void Configure (Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<RepostReply> builder)
        {
            builder.ToTable("RepostReplies");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.RepostId);

            builder.HasIndex(x => x.ReplyId);

            builder.Property(x => x.RepostId)
                .IsRequired(true);

            builder.Property(x => x.ReplyId)
                .IsRequired(true);
        }
    }
}
