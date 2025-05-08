using libraryChallenge.Models;
using libraryChallenge.Repositories;

namespace libraryChallenge.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public List<Author> GetAll()
    {
        return _authorRepository.GetAll();
    }

    public void AddAuthor(Author author)
    {
        _authorRepository.Add(author);
    }
}