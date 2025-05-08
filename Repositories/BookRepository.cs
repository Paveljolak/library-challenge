using libraryChallenge.Data;
using libraryChallenge.Models;
using Microsoft.EntityFrameworkCore;

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
}