using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using RrsChronosTimeSheet.Core.Infrastructure.IoC.DependencyInjection;
using RrsChronosTimeSheet.Core.Web.Api.Config;
using Scalar.AspNetCore;

namespace RrsChronosTimeSheet.Core.Web.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private IWebHostEnvironment Environment { get; }

        public Startup(
            IConfiguration configuration,
            IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            ConfigureCors(services);
            ConfigureOpenApi(services);

            services.ConfigureRepository(Configuration);

            DependecyInjection.ResolveDependecies(services);
            ConfigurationApplication.RegisterApplication(services);
        }

        private void ConfigureOpenApi(IServiceCollection services)
        {
            // Nota: AddOpenApi não está disponível na configuração padrão do .NET 10
            // Para usar OpenAPI, instale o pacote Microsoft.AspNetCore.OpenApi
            // Exemplo de configuração comentado abaixo:

            // services.AddOpenApi("v1", options =>
            // {
            //     options.AddDocumentTransformer((document, context, cancellationToken) =>
            //     {
            //         document.Info = new OpenApiInfo
            //         {
            //             Title = Configuration["ApiInfo:Titulo"],
            //             Description = Configuration["ApiInfo:Descricao"],
            //             Version = string.Concat(
            //                 Configuration["ApiInfo:Versao:Major"], ".",
            //                 Configuration["ApiInfo:Versao:Minor"], ".",
            //                 Configuration["ApiInfo:Versao:Patch"])
            //         };
            //
            //         document.Servers =
            //         [
            //             new()
            //             {
            //                 Url = Configuration["ApiInfo:Servidor:Local"],
            //                 Description = "Local"
            //             },
            //             new()
            //             {
            //                 Url = Configuration["ApiInfo:Servidor:Producao"],
            //                 Description = "Produção"
            //             }
            //         ];
            //
            //         document.ExternalDocs = new OpenApiExternalDocs
            //         {
            //             Description = "Documentação Externa",
            //             Url = new Uri("https://www.google.com")
            //         };
            //
            //         return Task.CompletedTask;
            //     });
            // });
        }

        private void ConfigureCors(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("Default", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });
        }

        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("Default");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                // OpenAPI JSON - Comentado: requer pacote Microsoft.AspNetCore.OpenApi
                // endpoints.MapOpenApi("/openapi/{documentName}.json");

                // Scalar UI
                endpoints.MapScalarApiReference(options =>
                {
                    options.Title = "Documentação - RrsChronosTimeSheet API";
                    options.Theme = ScalarTheme.BluePlanet;
                    options.ForceDarkMode();
                });
            });
        }
    }
}