using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Domain.Relations;

namespace Threads.Persistence.Configurations.Relations
{
    public class UserBlockConfiguration : IEntityTypeConfiguration<UserBlock>
    {
        public void Configure (Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserBlock> builder)
        {
            builder.ToTable("UserBlocks");

            builder.HasKey(x => new { x.BlockerId, x.BlockedId });

            builder.HasIndex(x => x.BlockerId);

            builder.HasIndex(x => x.BlockedId);

            builder.Property(x => x.BlockerId)
                .IsRequired(true);

            builder.Property(x => x.BlockedId)
                .IsRequired(true);

            builder.HasOne(x => x.Blocker)
                .WithMany(x => x.Blockers)
                .HasForeignKey(x => x.BlockerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Blocked)
                .WithMany(x => x.Blockeds)
                .HasForeignKey(x => x.BlockedId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
