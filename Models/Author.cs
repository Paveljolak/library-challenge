namespace libraryChallenge.Models;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; } = null!; // null! -> to shut up null warnings.
    public DateTime DateOfBirth { get; set; }

    public List<Book> Books { get; set; } = new(); // used to define one-to-many relationship. Do I know why? Noup.

}