using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleWebApplication.Models.Daos;
[Table("Reviews")]
public class ReviewDao
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Text { get; set; } = null!;
    public int Rating { get; set; }
    public PokemonDao PokemonDao { get; set; } = null!;
    public ReviewerDao ReviewerDao { get; set; } = null!;
}