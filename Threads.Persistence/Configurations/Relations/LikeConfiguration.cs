using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Domain.Relations;

namespace Threads.Persistence.Configurations.Relations
{
    public class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure (Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Like> builder)
        {
            builder.ToTable("Likes");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.UserId);

            builder.HasIndex(x => x.PostId);

            builder.HasIndex(x => x.ReplyId);

            builder.Property(x => x.UserId)
                .IsRequired(true);

            builder.Property(x => x.PostId)
                .IsRequired(false);

            builder.Property(x => x.ReplyId)
                .IsRequired(false);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Likes)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Post)
                .WithMany(x => x.Likes)
                .HasForeignKey(x => x.PostId);

            builder.HasOne(x => x.Reply)
                .WithMany(x => x.Likes)
                .HasForeignKey(x => x.ReplyId);
        }
    }
}
