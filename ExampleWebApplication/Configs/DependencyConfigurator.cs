using ExampleWebApplication.Interfaces;
using ExampleWebApplication.Mappers;
using ExampleWebApplication.Repository;

namespace ExampleWebApplication.Configs;

public static class DependencyConfigurator
{
    public static WebApplicationBuilder AddDependencies(this WebApplicationBuilder webApplicationBuilder)
    {
        webApplicationBuilder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
        webApplicationBuilder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        webApplicationBuilder.Services.AddScoped<ICountryRepository, CountryRepository>();
        webApplicationBuilder.Services.AddScoped<ICategoryMapper, CategoryMapper>();
        webApplicationBuilder.Services.AddScoped<IPokemonMapper, PokemonMapper>();
        webApplicationBuilder.Services.AddScoped<ICountryMapper, CountryMapper>();
        webApplicationBuilder.Services.AddScoped<IOwnerMapper, OwnerMapper>();
        return webApplicationBuilder;
    }
}