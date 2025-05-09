using libraryChallenge.Models;
using libraryChallenge.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

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
        if (author == null || string.IsNullOrWhiteSpace(author.Name) || author.DateOfBirth == DateTime.MinValue)
        {
            var message = string.Empty;

            if (author == null)
            {
                message = "No Author data is added.";
            }
            else if (string.IsNullOrWhiteSpace(author.Name))
            {
                message = "No Author name is added.";
            }
            else if (author.DateOfBirth == DateTime.MinValue)
            {
                message = "No Author date of birth is added.";
            }
            throw new InvalidDataException(message);
        }

        _authorRepository.Add(author);
    }
}