﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Domain.Entities;

namespace Threads.Persistence.Configurations.Entities
{
    public class QuoteConfiguration : IEntityTypeConfiguration<Quote>
    {
        public void Configure (Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Quote> builder)
        {
            builder.ToTable("Quotes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Content)
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

            builder.HasOne(x => x.Post)
                .WithMany(x => x.Quotes)
                .HasForeignKey(x => x.PostId);

            builder.HasOne(x => x.Reply)
                .WithMany(x => x.Quotes)
                .HasForeignKey(x => x.ReplyId);

            builder.HasMany(x => x.Polls)
                .WithOne(x => x.Quote)
                .HasForeignKey(x => x.QuoteId);
        }
    }
}
