using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Domain.Relations;

namespace Threads.Persistence.Configurations.Relations
{
    public class UserFollowConfiguration : IEntityTypeConfiguration<UserFollow>
    {
        public void Configure (EntityTypeBuilder<UserFollow> builder)
        {
            builder.ToTable("UserFollows");

            builder.HasKey(x => new { x.FollowerId, x.FollowedId });

            builder.HasIndex(x => x.FollowerId);

            builder.HasIndex(x => x.FollowedId);

            builder.Property(x => x.FollowerId)
                .IsRequired(true);

            builder.Property(x => x.FollowedId)
                .IsRequired(true);

            builder.HasOne(x => x.Follower)
                .WithMany(x => x.Followers)
                .HasForeignKey(x => x.FollowerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Followed)
                .WithMany(x => x.Followeds)
                .HasForeignKey(x => x.FollowedId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
