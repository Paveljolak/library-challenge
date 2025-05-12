using libraryChallenge.Models;

namespace libraryChallenge.Services;

public interface IAuthorService
{
    List<Author> GetAll();
    void AddAuthor(Author author);
}