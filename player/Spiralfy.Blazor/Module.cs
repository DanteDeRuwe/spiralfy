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
        public static void Main(string[] args)
        {
            // should remain empty
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ISpotifyClient>(_ => new SpotifyClient("BQCr6ZsHjkEu35dHpxCrY9OIDma_eaM0EBv8zMXfUc4coLLkKt55gn0o8fxZnnVRFXaeljptKPJroPdhwZlPPPiWOsdsmmN6QFNJeKVpxNTMpoSlITvMl8bgya_3xXiIQwqCY_3tRa3cuAbtjwWM8QC3N6M"));
            services.AddScoped<ISpiralfyPlayer, SpiralfyPlayer>();
            services.AddScoped<ISpiralfyService, SpiralfyService>();
        }
    }
}
