using Microsoft.Extensions.DependencyInjection;

namespace Spiralfy.Blazor
{
    public class Module
    {
        public static void Main(string[] args) { }

        public static void ConfigureServices(IServiceCollection services)
        {
            // services.AddScoped<ISpiralfyPlayer, SpiralfyPlayer>();
            // services.AddScoped<ISpiralfyService, SpiralfyService>();
        }
    }
}
