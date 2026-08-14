using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Context;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts.Clientes;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts.Fornecedores;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts.TipoTelefone;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Repository;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Repository.Clientes;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Repository.Fornecedores;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Repository.TiposTelefone;
using RrsChronosTimeSheet.Core.Infrastructure.IoC.DependencyInjection;
using RrsChronosTimeSheet.Core.Infrastructure.IoC.Utils.Notifications;
using RrsChronosTimeSheet.Core.Infrastructure.IoC.Utils.Notifications.Contracts;

namespace RrsChronosTimeSheet.Core.Web.Api.Config
{
    public static class DependecyInjection
    {
        public static IServiceCollection ResolveDependecies(this IServiceCollection services)
        {
            services.AddScoped<ChronosContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IBaseCommandRepository<>), typeof(BaseCommandRepository<>));
            services.AddScoped(typeof(IBaseQuerysRepository<>), typeof(BaseQuerysRepository<>));
            services.AddScoped(typeof(IClienteRepository<Cliente>), typeof(ClienteRepository));
            services.AddScoped(typeof(IEmailClienteRepository<EmailCliente>), typeof(EmailClienteRepository));
            services.AddScoped(typeof(IFornecedorRepository<Fornecedor>), typeof(FornecedorRepository));
            services.AddScoped(typeof(ITiposTelefoneRepository<TipoTelefone>), typeof(TiposTelefoneRepository));
            
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped<IUser, AspNetUser>();

            services.AddScoped<INotifications, Notifier>();

            // Registrar AutoMapper e Services do Core.Services
            // AutoMapper registra o IMapper necessário para injeção de dependência
            services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
            });

            return services;
        }
    }
}
