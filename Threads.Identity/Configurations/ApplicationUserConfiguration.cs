using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Identity.Models;

namespace Threads.Identity.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<AuthenticationUser>
    {
        public void Configure (EntityTypeBuilder<AuthenticationUser> builder)
        {
            builder.ToTable("Users");
        }
    }
}
