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
    public class PollOptionConfiguration : IEntityTypeConfiguration<PollOption>
    {
        public void Configure (EntityTypeBuilder<PollOption> builder)
        {
            builder.ToTable("PollOptions");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.PollId);

            builder.Property(x => x.PollId)
                .IsRequired(true);

            builder.Property(x => x.Option)
                .IsRequired(true);

            builder.HasOne(x => x.Poll)
                .WithMany(x => x.PollOptions)
                .HasForeignKey(x => x.PollId);

            builder.HasMany(x => x.UserPollOptions)
                .WithOne(x => x.PollOption)
                .HasForeignKey(x => x.PollOptionId);
        }
    }
}
