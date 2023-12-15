using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Domain.Entities;

namespace Threads.Persistence.Configurations.Entities
{
    public class SearchConfiguration : IEntityTypeConfiguration<Search>
    {
        public void Configure (Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Search> builder)
        {
            builder.ToTable("Searches");

            builder.HasKey(x => new { x.SearchId, x.UserId });

            builder.Property(x => x.SearchId)
                .IsRequired(true);

            builder.Property(x => x.UserId)
                .IsRequired(true);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Searches)
                .HasForeignKey(x => x.SearchId);
        }
    }
}
