using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Spiralfy.Core;
using Spiralfy.Core.Interfaces;
using SpotifyAPI.Web;

namespace Spiralfy.Blazor
{
    public class Program
    {
        private static IConfigurationRoot _configuration;

        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            _configuration = builder.Configuration;
            ConfigureServices(builder.Services);

            var host = builder.Build();
            Configure(host);

            await host.RunAsync();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ISpotifyClient>(_ => new SpotifyClient(_configuration["SpotifyToken"]));
            services.AddScoped<ISpiralfyPlayer, SpiralfyPlayer>();
            services.AddScoped<ISpiralfyService, SpiralfyService>();
        }

        private static void Configure(WebAssemblyHost host) { }
    }
}
