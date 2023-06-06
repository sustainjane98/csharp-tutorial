using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleWebApplication.Models.Daos;

[Table("Owners")]
public class OwnerDao
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Gym { get; set; } = null!;
    
    
    public int CountryId { get; set; }
    public Country Country { get; set; } = null!;
    
    public ICollection<PokemonDao> Pokemons { get; } = null!;

    public ICollection<PokemonOwnerDao> PokemonOwners { get; set; } = null!;
}