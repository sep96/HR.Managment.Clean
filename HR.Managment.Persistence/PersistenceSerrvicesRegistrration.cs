using HR.Managment.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Managment.Persistence
{
    public static class PersistenceSerrvicesRegistrration
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddDbContext<HrDatabaseContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("Connectionstring"));
                });
            return services;
        }
    }
}
