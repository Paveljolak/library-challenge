using libraryChallenge.Models;
using libraryChallenge.Repositories;

namespace libraryChallenge.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public List<Book> GetAllBooks(int page, int pageSize)
    {
        return _bookRepository.GetAllBooks(page, pageSize);
    }

    public Book GetBookById(int id)
    {
        var book = _bookRepository.GetBookById(id);

        if (book == null)
        {
            throw new Exception("Book not found");
        }

        return book;
    }

    public void AddBook(Book book)
    {
        if (book == null)
        {
            throw new ArgumentException("Invalid book data.");
        }
        _bookRepository.AddBook(book);
    }

    public void UpdateBook(int id, Book book)
    {
        var existingBook = _bookRepository.GetBookById(id);

        if (existingBook == null)
        {
            throw new Exception("Book not found");
        }
        
        existingBook.Title = book.Title;
        existingBook.PublicationYear = book.PublicationYear;
        existingBook.AuthorId = book.AuthorId;

        _bookRepository.UpdateBook(id, existingBook);
    }

    public void DeleteBook(int id)
    {
        var book = _bookRepository.GetBookById(id);

        if (book == null)
        {
            throw new Exception("Book not found");
        }
        
        _bookRepository.DeleteBook(id);
    }
}