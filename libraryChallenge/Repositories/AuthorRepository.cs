using libraryChallenge.Data;
using libraryChallenge.Models;

namespace libraryChallenge.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly ApplicationDbContext _context;

    public AuthorRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Author> GetAll()
    {
        return _context.Authors.ToList();
    }

    public void Add(Author author)
    {
        _context.Authors.Add(author);
        _context.SaveChanges();
    }
}