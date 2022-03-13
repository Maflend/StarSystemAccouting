using Microsoft.Extensions.DependencyInjection;
using StarSystemAccouting.Application.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemAccouting.Application.Services
{
    public static class DependencyInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IStarSystemService, StarSystemService>();
            services.AddScoped<ISpaceObjectService, SpaceObjectService>();
        }
    }
}
