using Microsoft.Extensions.DependencyInjection;
using Spiralfy.Core;
using Spiralfy.Core.Interfaces;
using SpotifyAPI.Web;

namespace Spiralfy.Blazor
{
    public class Module
    {
        public static void Main(string[] args) { }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ISpotifyClient>(_ => new SpotifyClient("BQCvSUxLkzidD3vnKlLN7_aUEzzbfDnyjcmG9XlZ1-zcC3B6rAzmmVlcezjd6wo5ULD--O1XTOwLIkD7coZSjCd1OROK3OEO1Ucrth-xe8uHK2utHrClwchTkuo5qujsty2s370tbNdpvSK7NLqxDaeRdR0"));
            
            services.AddScoped<ISpiralfyPlayer, SpiralfyPlayer>();
            services.AddScoped<ISpiralfyService, SpiralfyService>();
        }
    }
}
