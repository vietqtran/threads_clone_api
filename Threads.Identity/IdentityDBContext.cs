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

            builder.ApplyConfiguration(new ApplicationUserConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
