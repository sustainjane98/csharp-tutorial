using ExampleWebApplication.Interfaces;
using ExampleWebApplication.Models;
using ExampleWebApplication.Models.Daos;
using Microsoft.EntityFrameworkCore;

namespace ExampleWebApplication.Repository;

public class PokemonRepository: IPokemonRepository
{
    private readonly ApplicationDbContext _context;

    public PokemonRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IQueryable<PokemonDao> GetPokemons()
    {
        return _context.Pokemons.AsQueryable();
    }

    public IQueryable<PokemonDao> GetPokemon(int id)
    {
        return _context.Pokemons.Where(p => p.Id == id);
    }

    public PokemonDao? GetPokemon(string name)
    {
        return _context.Pokemons.FirstOrDefault(p => p.Name == name);
    }

    public decimal PokemonRating(int pokeId)
    {
        var reviews = _context.Reviews.Where(p => p.PokemonDao.Id == pokeId);

        if (!PokemonExists(pokeId))
            return 0;

        return ((decimal) reviews.Sum(r => r.Rating)) / reviews.Count();
    }

    public bool PokemonExists(int pokeId) => _context.Pokemons.Any(p => p.Id == pokeId);
    
    public (int, bool) Create(PokemonDao pokemonDao)
    {

        if (pokemonDao.Id > 0)
        {
            pokemonDao.Id = 0;
        } 
        
        var id = _context.Pokemons.Add(pokemonDao).Entity.Id;

        return (id, Save());
    }
    
    public async Task<(int, bool)> CreateAsync(PokemonDao pokemonDao)
    {

        if (pokemonDao.Id > 0)
        {
            pokemonDao.Id = 0;
        } 
        
        var id = (await _context.Pokemons.AddAsync(pokemonDao)).Entity.Id; 
        var isSaved = await SaveAsync();
       
       return (id, isSaved);
    }
    
    public bool Save() => _context.SaveChanges() > 0;

    public async Task<bool> SaveAsync() => await _context.SaveChangesAsync() > 0;

    public (int, bool) Update (PokemonDao newPokemonDao)
    {
        
        var id = _context.Pokemons.Update(newPokemonDao).Entity.Id;

        return (id, Save());
    }
    
    public async Task<(int, bool)> UpdateAsync (PokemonDao newPokemonDao)
    {
        
        var id = _context.Pokemons.Update(newPokemonDao).Entity.Id;

        return (id, await SaveAsync());
    }
}