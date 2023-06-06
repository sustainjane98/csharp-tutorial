using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleWebApplication.Models.Daos;

[Table("PokemonCategories")]
public class PokemonCategory
{
    public int PokemonsId { get; set; }
    public int CategoriesId { get; set; }
    public PokemonDao PokemonDao { get; set; } = null!;
    public CategoryDao CategoryDao { get; set; } = null!;
}