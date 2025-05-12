using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace libraryChallenge.Models;

[Table("authors", Schema = "library_db")]
public class Author
{
    [Column("id")] public int Id { get; set; }

    [Column("name")] public string Name { get; set; } = null!;

    [Column("dateofbirth")] public DateTime DateOfBirth { get; set; }

    [JsonIgnore] 
    public List<Book> Books { get; set; } = new();
}