using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleWebApplication.Models.Daos;

[Table("Countries")]
public class Country
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<OwnerDao> Owners { get; set; } = null!;
}