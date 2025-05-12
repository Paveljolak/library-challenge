using libraryChallenge.Models;

namespace libraryChallenge.Repositories;

public interface IAuthorRepository
{
    List<Author> GetAll();
    void Add(Author author);
}