using libraryChallenge.Models;
using libraryChallenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace libraryChallenge.Controllers
{
    [Route("books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<List<Book>> GetAllBooks([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var books = _bookService.GetAllBooks(page, pageSize);
                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            try
            {
                var book = _bookService.GetBookById(id);
                if (book == null)
                {
                    return NotFound(new { message = "Book not found" });
                }

                return Ok(book);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult AddBook([FromBody] Book book)
        {
            try
            {
                _bookService.AddBook(book);
                return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBook(int id, [FromBody] Book book)
        {
            try
            {
                _bookService.UpdateBook(id, book);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id)
        {
            try
            {
                _bookService.DeleteBook(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}