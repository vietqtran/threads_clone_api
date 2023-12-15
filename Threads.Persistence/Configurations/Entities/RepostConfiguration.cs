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
    public class RepostConfiguration : IEntityTypeConfiguration<Repost>
    {
        public void Configure (EntityTypeBuilder<Repost> builder)
        {
            builder.ToTable("Reposts");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.IsHide)
                .IsRequired(true)
                .HasDefaultValue(true);

            builder.Property(x => x.UserId)
                .IsRequired(true);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired(true);

            builder.Property(x => x.UpdatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired(true);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Reposts)
                .HasForeignKey(x => x.UserId);

            builder.HasMany(x => x.RepostReplies)
                .WithOne(x => x.Repost)
                .HasForeignKey(x => x.RepostId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.RepostPosts)
                .WithOne(x => x.Repost)
                .HasForeignKey(x => x.RepostId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
