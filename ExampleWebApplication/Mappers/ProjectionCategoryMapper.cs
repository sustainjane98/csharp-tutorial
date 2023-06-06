using ExampleWebApplication.Dtos;
using ExampleWebApplication.Models;
using ExampleWebApplication.Models.Daos;
using ExampleWebApplication.Models.Dtos;

namespace ExampleWebApplication.Mappers;


public static class ProjectionCategoryMapper
{
    public static IQueryable<Category> ProjectToDto(this IQueryable<CategoryDao> category) => category.Select(e => new Category
    {
        Id = e.Id,
        Name = e.Name,
        Pokemons = e.Pokemons.Select(pokemonDao => new PokemonMapper().ToDto(pokemonDao))
    });
}