using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Domain.Entities;
using Threads.Domain.Enums;

namespace Threads.Persistence.Configurations.Entities
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure (EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");

            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.UserId);

            builder.Property(p => p.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();

            builder.Property(p => p.UpdatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();

            builder.Property(x => x.UserId)
            .IsRequired();

            builder.Property(x => x.Content)
                .IsRequired(false);

            builder.Property(x => x.ReplyAudience)
                .HasDefaultValue(ReplyAudience.ANYONE)
                .HasConversion<int>();

            builder.Property(x => x.ThreadType)
                .HasDefaultValue(ThreadType.POST)
                .HasConversion<int>();

            builder.HasOne(x => x.User)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.UserId);

            builder.HasMany(x => x.Replies)
                .WithOne(x => x.Post)
                .HasForeignKey(x => x.PostId);

            builder.HasMany(x => x.Quotes)
                .WithOne(x => x.Post)
                .HasForeignKey(x => x.PostId);

            builder.HasMany(x => x.Polls)
                .WithOne(x => x.Post)
                .HasForeignKey(x => x.PostId);

            builder.HasMany(x => x.Medias)
                .WithOne(x => x.Post)
                .HasForeignKey(x => x.PostId);

            builder.HasMany(x => x.RepostPosts)
                .WithOne(x => x.Post)
                .HasForeignKey(x => x.PostId);

            builder.HasMany(x => x.Likes)
                .WithOne(x => x.Post)
                .HasForeignKey(x => x.PostId);
        }
    }
}
