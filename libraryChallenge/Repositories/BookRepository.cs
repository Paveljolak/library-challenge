using libraryChallenge.Data;
using libraryChallenge.Models;
using Microsoft.EntityFrameworkCore;
using FuzzySharp;


namespace libraryChallenge.Repositories;

public class BookRepository : IBookRepository
{
    private readonly ApplicationDbContext _context;


    public BookRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Book> GetAllBooks(int page, int pageSize)
    {
        var skip = (page - 1) * pageSize;
        return _context.Books.Skip(skip).Take(pageSize).ToList();
    }

    public Book GetBookById(int id)
    {
        return _context.Books.FirstOrDefault(b => b.Id == id);
    }

    public void AddBook(Book book)
    {
        _context.Books.Add(book);
        _context.SaveChanges();
    }

    public void UpdateBook(int id, Book book)
    {
        var existingBook = _context.Books.FirstOrDefault(b => b.Id == id);

        if (existingBook != null)
        {
            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.AuthorId = book.AuthorId;

            _context.SaveChanges();
        }
    }

    public void DeleteBook(int id)
    {
        var book = _context.Books.FirstOrDefault(b => b.Id == id);

        if (book != null)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }

    // Searching for similar title by combining both In-Memory and Database Search
    public List<Book> SearchBooksByTitle(string title, int maxResults)
    {
        // Database search
        List<Book> resultBooksFromDb = SearchBooksByTitleInDatabase(title, 200); // Fetch 200 books from the DB

        if (resultBooksFromDb.Any())
        {
            // In memory search
            var refinedResults = SearchBooksByTitleInMemory(title, resultBooksFromDb);

            // Limit final results to maxResults
            return refinedResults.Take(maxResults).ToList();
        }

        return new List<Book>(); 
    }

    // In-Memory Search Using FuzzySharp
    private List<Book> SearchBooksByTitleInMemory(string title, List<Book> allBooks)
    {
        // In memory search by calculating fuzzy similarity scores using FuzzySharp
        var results = allBooks
            .Select(book => new
            {
                book,
                score = Fuzz.Ratio(book.Title, title) // Compute similarity score
            })
            .Where(x => x.score > 30) // Filter based on a threshold (score > 30)
            .OrderByDescending(x => x.score) // Order by similarity score
            .Select(x => x.book)
            .ToList();

        return results;
    }

    // Database Search using pg_trgm
    private List<Book> SearchBooksByTitleInDatabase(string title, int maxResults)
    {
        var sql = @"
        SELECT * FROM library_db.books
        WHERE similarity(title, {0}) > 0.3
        ORDER BY similarity(title, {0}) DESC
        LIMIT {1};
    ";

        // Fetch maxResults number of books from the database
        return _context.Books
            .FromSqlRaw(sql, title, maxResults)
            .AsNoTracking()
            .ToList();
    }
}