using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleWebApplication.Models.Daos;

[Table("Pokemons")]
public class PokemonDao
{
    public int Id {get; set; }
    public string Name { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public ICollection<ReviewDao> Reviews { get; set; } = null!;
    
    public ICollection<CategoryDao> Categories { get; } = null!;
    
    
    public ICollection<OwnerDao> Owners { get; } = null!;
    public ICollection<PokemonCategory> PokemonCategories { get; } = null!;
    public ICollection<PokemonOwnerDao> PokemonOwners { get; } = null!;
}