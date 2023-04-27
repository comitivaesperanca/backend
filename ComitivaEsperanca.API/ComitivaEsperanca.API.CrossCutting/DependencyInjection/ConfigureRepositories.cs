using ComitivaEsperanca.API.Data.Context;
using Microsoft.EntityFrameworkCore;
using ComitivaEsperanca.API.Data.Repositories;
using ComitivaEsperanca.API.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SesiFlow.API.CrossCutting.DependencyInjection
{
    public class ConfigureRepositories
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CoreContext>(
                options => options.UseNpgsql(configuration.GetConnectionString("Default"))
            );

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        }
    }
}