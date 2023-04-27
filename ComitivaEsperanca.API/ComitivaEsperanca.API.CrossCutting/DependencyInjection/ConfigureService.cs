using ComitivaEsperanca.API.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ComitivaEsperanca.API.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<NewsService>();
        }
    }
}
