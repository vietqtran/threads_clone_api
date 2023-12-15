using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Domain.Relations;

namespace Threads.Persistence.Configurations.Relations
{
    public class UserPollOptionsConfiguration : IEntityTypeConfiguration<UserPollOptions>
    {
        public void Configure (Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserPollOptions> builder)
        {
            builder.ToTable("UserPollOptions");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.UserId);

            builder.HasIndex(x => x.PollOptionId);

            builder.Property(x => x.UserId)
                .IsRequired(true);

            builder.Property(x => x.PollOptionId)
                .IsRequired(true);

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserPollOptions)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.PollOption)
                .WithMany(x => x.UserPollOptions)
                .HasForeignKey(x => x.PollOptionId);
        }
    }
}
