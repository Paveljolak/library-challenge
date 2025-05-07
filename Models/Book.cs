namespace libraryChallenge.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public int PublicationYear { get; set; }
    
    public int AuthorId { get; set; }
    public Author Author { get; set; } = null!; // many-to-one relationship. The same as in Author, but now for book.
    
}