using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Domain.Entities;

namespace Threads.Persistence.Configurations.Entities
{
    public class PollConfiguration : IEntityTypeConfiguration<Poll>
    {
        public void Configure (Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Poll> builder)
        {
            builder.ToTable("Polls");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Question)
                .IsRequired(true);

            builder.Property(x => x.QuoteId)
                .IsRequired(false);

            builder.Property(x => x.PostId)
                .IsRequired(false);

            builder.Property(x => x.ReplyId)
                .IsRequired(false);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();

            builder.Property(x => x.UpdatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();

            builder.HasOne(x => x.Quote)
                .WithMany(x => x.Polls)
                .HasForeignKey(x => x.QuoteId);

            builder.HasOne(x => x.Post)
                .WithMany(x => x.Polls)
                .HasForeignKey(x => x.PostId);

            builder.HasOne(x => x.Reply)
                .WithMany(x => x.Polls)
                .HasForeignKey(x => x.ReplyId);

            builder.HasMany(x => x.PollOptions)
                .WithOne(x => x.Poll)
                .HasForeignKey(x => x.PollId);
        }
    }
}
