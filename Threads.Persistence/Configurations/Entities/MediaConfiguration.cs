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
    public class MediaConfiguration : IEntityTypeConfiguration<Media>
    {
        public void Configure (EntityTypeBuilder<Media> builder)
        {
            builder.ToTable("Medias");

            builder.HasKey(m => m.Id);

            builder.HasIndex(m => m.PostId);

            builder.HasIndex(m => m.ReplyId);

            builder.Property(m => m.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();

            builder.Property(m => m.UpdatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();

            builder.Property(e => e.Url)
                .HasColumnType("ntext")
                .IsRequired();

            builder.Property(e => e.Type)
                .IsRequired()
                .HasConversion<MediaType>();

            builder.Property(e => e.Alt)
                .IsRequired();

            builder.Property(e => e.PostId)
                .IsRequired(false);

            builder.Property(e => e.ReplyId)
                .IsRequired(false);

            builder.HasOne(x => x.Post)
                .WithMany(x => x.Medias)
                .HasForeignKey(x => x.PostId);

            builder.HasOne(x => x.Reply)
                .WithMany(x => x.Medias)
                .HasForeignKey(x => x.ReplyId);
        }
    }
}
