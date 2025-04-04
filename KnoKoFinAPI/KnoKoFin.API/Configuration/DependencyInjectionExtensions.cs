using FluentValidation;
using KnoKoFin.Application.Common.Behaviours;
using KnoKoFin.Application.Interfaces;
using KnoKoFin.Application.Interfaces.Repositories;
using KnoKoFin.Application.Services.Dictionaries.Addresses.Commands.CreateAddress;
using KnoKoFin.Domain.Helpers;
using KnoKoFin.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace KnoKoFin.API.Configuration
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Rejestracja MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            // Rejestracja FluentValidation
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // Rejestracja pipeline behaviors
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehavior<,>));

            // Rejestracja repozytorium i mappera
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<CreateAddressMapper>();
            services.AddSingleton<IDateTime, ApplicationDateTime>();

            return services;
        }
    }
}

