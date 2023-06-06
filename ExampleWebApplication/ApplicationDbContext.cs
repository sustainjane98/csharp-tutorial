using ExampleWebApplication.Models;
using ExampleWebApplication.Models.Daos;
using Microsoft.EntityFrameworkCore;

namespace ExampleWebApplication;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PokemonDao>()
            .HasMany(e => e.Categories)
            .WithMany(e => e.Pokemons)
            .UsingEntity<PokemonCategory>(l => l.HasOne(e => e.CategoryDao).WithMany(e => e.PokemonCategories),
                r => r.HasOne(m => m.PokemonDao).WithMany(e => e.PokemonCategories));

        modelBuilder.Entity<PokemonDao>()
            .HasMany(e => e.Owners)
            .WithMany(e => e.Pokemons)
            .UsingEntity<PokemonOwnerDao>(l => 
                l.HasOne(e => e.OwnerDao).WithMany(e => e.PokemonOwners), 
                r => r.HasOne(e => e.PokemonDao).WithMany(e => e.PokemonOwners));
    }

    public DbSet<PokemonDao> Pokemons { get; set; } = null!;
    public DbSet<PokemonOwnerDao> PokemonOwners { get; set; } = null!;
    public DbSet<PokemonCategory> PokemonCategories { get; set; } = null!;
    public DbSet<CategoryDao> Categories { get; set; } = null!;
    public DbSet<Country> Countries { get; set; } = null!;
    public DbSet<OwnerDao> Owners { get; set; } = null!;
    public DbSet<ReviewDao> Reviews { get; set; } = null!;
    public DbSet<ReviewerDao> Reviewers { get; set; } = null!;
}