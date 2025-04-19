using Microsoft.AspNetCore.Mvc;
using DotNet_API_E_Book_Application.Model;
using DotNet_API_E_Book_Application.Data;
using Microsoft.EntityFrameworkCore;

namespace DotNet_API_E_Book_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly AppDbContext _db;
        public BookController(AppDbContext db)
        {
            _db = db;
        }

        [HttpPost("addBook")]
        public IActionResult AddBook(Book book)
        {
            if (book == null)
            {
                return BadRequest(new { status = 404, message = "Book data is required" });
            }

            _db.Books.Add(book);
            _db.SaveChanges();
            return Ok(new {status=200, message="Books successfully Added"});
        }

        [HttpGet("getBook")]
        public IActionResult GetBook()
        {
            var books = _db.Books.ToList();
            return Ok(new {status=200, message="All books are retrived", data = books});
        }

        [HttpGet("getBook/{id}")]
        public IActionResult GetBookByID(int id)
        {
            var book = _db.Books.FirstOrDefault(x => x.Id == id);

            if(book == null)
            {
                return NotFound(new { status = 404, message = $"Book Not found in this ID = {id}" });
            }

            return Ok(new { status = 200, message = "Book retrived", data = book });
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateBook(int id, Book updatedBook)
        {
            var book = _db.Books.FirstOrDefault(x => x.Id == id);

            if (book == null)
                return NotFound(new { status = 404, message = $"Book with ID {id} not found" });

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Description = updatedBook.Description;

            _db.SaveChanges();

            return Ok(new { status = 200, message = "Book updated successfully", data = book });
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _db.Books.FirstOrDefault(x => x.Id == id);

            if (book == null)
                return NotFound(new { status = 404, message = $"Book with ID {id} not found" });

            _db.Books.Remove(book);
            _db.SaveChanges();

            return Ok(new { status = 200, message = "Book deleted successfully" });
        }
    }
}
