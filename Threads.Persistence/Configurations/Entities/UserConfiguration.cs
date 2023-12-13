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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure (EntityTypeBuilder<User> builder)
        {
            // Primary key
            builder.HasKey(u => u.Id);

            // Required properties
            builder.Property(u => u.Name).IsRequired();
            builder.Property(u => u.UserName).IsRequired();
            builder.Property(u => u.Email).IsRequired();

            // AllowNull properties
            builder.Property(u => u.ProfilePicture).IsRequired(false);
            builder.Property(u => u.Bio).IsRequired(false);

            // Default values
            builder.Property(u => u.IsPrivate).HasDefaultValue(false);
            builder.Property(u => u.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(u => u.UpdatedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(u => u.IsDeleted).HasDefaultValue(false);
            builder.Property(u => u.IsLocked).HasDefaultValue(false);
        }
    }
}
