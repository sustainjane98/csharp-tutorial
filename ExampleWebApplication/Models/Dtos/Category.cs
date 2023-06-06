using ExampleWebApplication.Models;
using ExampleWebApplication.Models.Dtos;

namespace ExampleWebApplication.Dtos;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public IEnumerable<Pokemon> Pokemons { get; set; } = null!;
}