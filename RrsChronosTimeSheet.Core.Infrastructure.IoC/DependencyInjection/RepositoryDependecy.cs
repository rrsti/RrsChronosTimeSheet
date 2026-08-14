using RrsChronosTimeSheet.Core.Infrastructure.Data.Context;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RrsChronosTimeSheet.Core.Infrastructure.IoC.DependencyInjection
{
    /// <summary>
    /// Configuração de injeção de dependência para repositórios e Unit of Work.
    /// </summary>
    public static class RepositoryDependecy
    {
        /// <summary>
        /// Configura os serviços de repositório e Unit of Work no container de injeção de dependência.
        /// </summary>
        /// <param name="services">Coleção de serviços.</param>
        /// <param name="configuration">Configuração da aplicação.</param>
        /// <returns>Coleção de serviços configurada.</returns>
        public static IServiceCollection ConfigureRepository(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // Configurar DbContext
            services.AddDbContext<ChronosContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("ChronosTSConnection"),
                    migrationOptions => migrationOptions.MigrationsAssembly(
                        typeof(ChronosContext).Assembly.FullName));
            });

            // Registrar Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
