using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Identity.Configurations;
using Threads.Identity.Models;

namespace Threads.Identity
{
    public class IdentityDBContext : IdentityDbContext<ApplicationUser, Role, Guid>
    {
        public IdentityDBContext (DbContextOptions<IdentityDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating (ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(b =>
            {
                b.Property(u => u.Id).HasDefaultValueSql("newsequentialid()");
            });
            builder.ApplyConfiguration(new ApplicationUserConfiguration());

            builder.Entity<Role>(b =>
            {
                b.Property(r => r.Id).HasDefaultValueSql("newsequentialid()");
            });
            builder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
