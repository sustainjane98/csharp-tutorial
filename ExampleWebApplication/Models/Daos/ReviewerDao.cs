using System.ComponentModel.DataAnnotations.Schema;
using ExampleWebApplication.Models.Daos;

namespace ExampleWebApplication.Models;

[Table("Reviewers")]
public class ReviewerDao
{
    public int Id { get; set; }
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public ICollection<ReviewDao> Reviews { get; set; } = null!;
}