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

    public List<Book> SearchBooksByTitle(string title, int maxResults)
    {
        return _bookRepository.SearchBooksByTitle(title, maxResults);
    }

    public void AddBook(Book book)
    {
        if (book == null || string.IsNullOrEmpty(book.Title) || book.PublicationYear == 0 || book.AuthorId == 0)
        {
            var message = string.Empty;
            if (book == null)
            {
                message = "Book not found";
            }
            else if (string.IsNullOrEmpty(book.Title))
            {
                message = "Title not found";
            }
            else if (book.PublicationYear == 0)
            {
                message = "Publication Year not found.";
            }
            else if (book.AuthorId == 0)
            {
                message = "Author Id was not found.";
            }

            throw new ArgumentException(message);
        }

        _bookRepository.AddBook(book);
    }

    // Some test
    public void UpdateBook(int id, Book book)
    {
        if (book == null || string.IsNullOrEmpty(book.Title) || book.PublicationYear == 0 || book.AuthorId == 0)
        {
            var message = string.Empty;
            if (book == null)
            {
                message = "Book not found";
            }
            else if (string.IsNullOrEmpty(book.Title))
            {
                message = "Title not found";
            }
            else if (book.PublicationYear == 0)
            {
                message = "Publication Year not found.";
            }
            else if (book.AuthorId == 0)
            {
                message = "Author Id was not found.";
            }

            throw new ArgumentException(message);
        }

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