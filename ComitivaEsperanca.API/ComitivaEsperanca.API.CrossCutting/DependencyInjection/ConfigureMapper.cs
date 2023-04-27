using AutoMapper;
using ComitivaEsperanca.API.Domain.DTOs;
using ComitivaEsperanca.API.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

public class ConfigureMappers
{
    public static void Configure(IServiceCollection services)
    {
        services.AddSingleton(new MapperConfiguration(config =>
        {
            #region [News]
            config.CreateMap<News, NewsDTO>();
            config.CreateMap<NewsDTO, News>();
            #endregion

        }).CreateMapper());
    }
}