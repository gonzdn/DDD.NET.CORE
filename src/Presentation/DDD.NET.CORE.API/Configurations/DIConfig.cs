using DDD.NET.CORE.APPLICATION.Application.Services.Car;
using DDD.NET.CORE.DOMAIN.Repositories.Contracts;
using DDD.NET.CORE.INFRAESTRUCTURE.Repositories.Car;
using Microsoft.Extensions.DependencyInjection;

namespace DDD.NET.CORE.API.Configurations
{
    public static class DIConfig
    {
        public static IServiceCollection AddDIConfig(this IServiceCollection services)
        {
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ICarService, CarService>();
            return services;
        }
    }

}