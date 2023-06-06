using System.ComponentModel.DataAnnotations;
using ExampleWebApplication.Dtos;

namespace ExampleWebApplication.Models.Dtos;

public class Pokemon
{
    [Key]
    public int? Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime BirthDate { get; set; }

    
    public IEnumerable<Category>? Categories { get; set; }


    public IEnumerable<Owner>? Owners { get; set; }
}