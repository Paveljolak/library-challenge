using libraryChallenge.Models;

namespace libraryChallenge.Repositories;

public interface IBookRepository
{
    List<Book> GetAllBooks(int page, int pageSize);
    Book? GetBookById(int id);
    void AddBook(Book book);
    void UpdateBook(int id, Book book);
    void DeleteBook(int id);

    List<Book> SearchBooksByTitle(string title, int maxResults);


}