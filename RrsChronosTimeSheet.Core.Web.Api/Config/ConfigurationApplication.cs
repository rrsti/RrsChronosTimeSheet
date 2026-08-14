using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using RrsChronosTimeSheet.Core.Application.UsersCases.Clientes.Queries;

namespace RrsChronosTimeSheet.Core.Web.Api.Config
{
    public static class ConfigurationApplication
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                // Registrar handlers do assembly Core.Application
                cfg.RegisterServicesFromAssembly(typeof(GetAllClienteQuery).Assembly);
            });

            //services.AddAutoMapper(typeof(ConfigurationApplication).Assembly);
            return services;
        }
    }
}
