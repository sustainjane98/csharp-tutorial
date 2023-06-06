using System.ComponentModel.DataAnnotations.Schema;
using ExampleWebApplication.Models.Daos;

namespace ExampleWebApplication.Models;

[Table("PokemonOwners")]
public class PokemonOwnerDao
{
    public int PokemonsId { get; set; }
    public int OwnersId { get; set; }
    public PokemonDao PokemonDao { get; set; } = null!;
    public OwnerDao OwnerDao { get; set; } = null!;
    
}