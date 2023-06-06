using ExampleWebApplication.Interfaces;
using ExampleWebApplication.Models;
using ExampleWebApplication.Models.Daos;
using Microsoft.EntityFrameworkCore;

namespace ExampleWebApplication.Repository;

public class CategoryRepository: ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public IQueryable<CategoryDao> GetCategories()
    {
        return _context.Categories.AsQueryable();
    }

    public IQueryable<CategoryDao> GetCategory(int id)
    {
        return _context.Categories.Where(p => p.Id == id);
    }

    public ICollection<PokemonDao> GetPokemonsByCategoryId(int categoryId)
    {
        return _context.PokemonCategories.Where(p => p.CategoriesId == categoryId).Select(a => a.PokemonDao).ToList();
    }

    public bool CategoryExists(int id) => _context.Categories.Any(p => p.Id == id);
}