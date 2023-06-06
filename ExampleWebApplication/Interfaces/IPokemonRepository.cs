using ExampleWebApplication.Models;
using ExampleWebApplication.Models.Daos;

namespace ExampleWebApplication.Interfaces;

public interface IPokemonRepository
{
    IQueryable<PokemonDao> GetPokemons();

    IQueryable<PokemonDao> GetPokemon(int id);

    PokemonDao? GetPokemon(string name);

    decimal PokemonRating(int pokeId);

    bool PokemonExists(int pokeId);

    (int, bool) Create(PokemonDao pokemonDao);

    public Task<(int, bool)> CreateAsync(PokemonDao pokemonDao);
    
    public Task<bool> SaveAsync();

    public bool Save();

    public (int, bool) Update(PokemonDao pokemonDao);
    
    public Task<(int, bool)> UpdateAsync(PokemonDao pokemonDao);
}