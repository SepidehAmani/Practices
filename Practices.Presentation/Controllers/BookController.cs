using Microsoft.AspNetCore.Mvc;
using Practices.Application.Services.Interfaces;

namespace Practices.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("GetAuthor/{id}")]
        public async Task<IActionResult> GetAuthorWithBooks(int id,CancellationToken cancellation)
        {
            var author = await _bookService.GetAuthorWithBooksById(id, cancellation);
            if (author == null) return NotFound();
            return Ok(author);
        }

        [HttpGet("GetBook/{id}")]
        public async Task<IActionResult> GetBook(int id, CancellationToken cancellation)
        {
            var book = await _bookService.GetBookById(id, cancellation);
            if (book == null) return NotFound();
            return Ok(book);
        }


    }
}
