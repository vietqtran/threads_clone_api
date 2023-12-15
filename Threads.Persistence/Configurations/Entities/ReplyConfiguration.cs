using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Domain.Entities;
using Threads.Domain.Enums;

namespace Threads.Persistence.Configurations.Entities
{
    public class ReplyConfiguration : IEntityTypeConfiguration<Reply>
    {
        public void Configure (Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Reply> builder)
        {
            builder.ToTable("Replies");

            builder.HasKey(x => x.Id);

            builder.Property(e => e.Content)
            .HasColumnType("ntext")
            .IsRequired();

            builder.Property(e => e.UserId)
                .IsRequired();

            builder.Property(e => e.PostId)
                .IsRequired(false);

            builder.Property(e => e.ThreadType)
                .HasDefaultValue(ThreadType.REPLY)
                .HasConversion<int>();

            builder.Property(e => e.ReplyAudience)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();

            builder.Property(x => x.UpdatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.Replies)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Post)
                .WithMany(x => x.Replies)
                .HasForeignKey(x => x.PostId);

            builder.HasMany(x => x.Quotes)
                .WithOne(x => x.Reply)
                .HasForeignKey(x => x.ReplyId);

            builder.HasMany(x => x.Medias)
                .WithOne(x => x.Reply)
                .HasForeignKey(x => x.ReplyId);

            builder.HasMany(x => x.Likes)
                .WithOne(x => x.Reply)
                .HasForeignKey(x => x.ReplyId);

            builder.HasMany(x => x.Polls)
                .WithOne(x => x.Reply)
                .HasForeignKey(x => x.ReplyId);

            builder.HasMany(x => x.RepostReplies)
                .WithOne(x => x.Reply)
                .HasForeignKey(x => x.ReplyId);
        }
    }
}
