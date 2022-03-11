using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StarSystemAccouting.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemAccouting.Persistence
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("PostgreConnection")));

            services.AddScoped<IAppContext>(provider => provider.GetService<AppContext>());
        }
    }
}
