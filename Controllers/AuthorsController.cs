using libraryChallenge.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace libraryChallenge.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorsController(ApplicationDbContext context) : ControllerBase
{
   [HttpGet]
   public async Task<IActionResult> GetAll()
   {
      var authors = await context.Authors.ToListAsync();

      if (!authors.Any())
      {
         return NotFound("No authors found.");
      }

      return Ok(authors);
   }

   
   [HttpGet("{id:int}")]
   public async Task<IActionResult> GetById(int id)
   {
      var author = await context.Authors.FirstOrDefaultAsync(a => a.Id == id);
      if (author == null)
      {
         return NotFound("Author not found.");
      }
      return Ok(author);
   }
}