using libraryChallenge.Models;

namespace libraryChallenge.Services;

public interface IBookService
{
    List<Book> GetAllBooks(int page, int pageSize);
    Book GetBookById(int id);
    List<Book> SearchBooksByTitle(string title, int maxResults);
    void AddBook(Book book);
    void UpdateBook(int id, Book book);
    void DeleteBook(int id);

}