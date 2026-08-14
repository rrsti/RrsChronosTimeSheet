using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using RrsChronosTimeSheet.Core.Web.Api;

public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var startup = new Startup(builder.Configuration, builder.Environment);

        startup.ConfigureServices(builder.Services);

        var app = builder.Build();

        startup.Configure(app, app.Environment);

        app.Run();
    }
}