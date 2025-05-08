using libraryChallenge.Data;
using libraryChallenge.Models;
using libraryChallenge.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace libraryChallenge.Controllers;

[ApiController]
[Route("authors")]
public class AuthorController(IAuthorService authorService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var authors = authorService.GetAll();

        if (!authors.Any())
        {
            return NotFound("No Authors Found.");
        }

        return Ok(authors);
    }

    [HttpPost]
    public IActionResult AddAuthor([FromBody] Author author)
    {
        if (author == null || string.IsNullOrWhiteSpace(author.Name) || author.DateOfBirth == null)
        {
            return BadRequest("Invalid author data.");
        }

        author.DateOfBirth = DateTime.SpecifyKind(author.DateOfBirth, DateTimeKind.Utc);
        authorService.AddAuthor(author);
        return Ok(author);
    }
}