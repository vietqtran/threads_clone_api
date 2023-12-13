using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threads.Application.Contracts.Persistence;
using Threads.Application.Contracts.Persistence.Generic;
using Threads.Application.Contracts.Persistence.Pattern;
using Threads.Persistence.Repositories;
using Threads.Persistence.Repositories.Generic;
using Threads.Persistence.Repositories.Pattern;

namespace Threads.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDBContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("ThreadsConnectionString")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
