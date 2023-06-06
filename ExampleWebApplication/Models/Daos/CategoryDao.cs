namespace ExampleWebApplication.Models.Daos;

public class CategoryDao
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<PokemonDao> Pokemons { get; } = null!;
    public ICollection<PokemonCategory> PokemonCategories { get; } = null!;
}