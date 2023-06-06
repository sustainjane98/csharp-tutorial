using ExampleWebApplication.Models;
using ExampleWebApplication.Models.Daos;

namespace ExampleWebApplication.Interfaces;

public interface ICategoryRepository
{
    IQueryable<CategoryDao> GetCategories();
    IQueryable<CategoryDao> GetCategory(int id);
    ICollection<PokemonDao> GetPokemonsByCategoryId(int categoryId);
    bool CategoryExists(int id);
}