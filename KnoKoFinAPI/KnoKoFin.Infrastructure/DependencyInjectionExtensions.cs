using KnoKoFin.Domain.Interfaces.Repositories.Dictionaries;
using KnoKoFin.Infrastructure.Repositories.Dictionaries.Addresses;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnoKoFin.Infrastructure
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IAddressRepository, AddressRepository>();
            return services;
        }
    }
}
