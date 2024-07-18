using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Practices.Application.DTOs;
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
        public async Task<IActionResult> GetAuthorWithBooks(int id,CancellationToken cancellation = default)
        {
            var author = await _bookService.GetAuthorWithBooksById(id, cancellation);
            if (author == null) return NotFound();
            return Ok(author);
        }

        [HttpGet("GetBook/{id}")]
        public async Task<IActionResult> GetBook(int id, CancellationToken cancellation = default)
        {
            var book = await _bookService.GetBookById(id, cancellation);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost("CreateAuthor")]
        public async Task<IActionResult> CreateAuthor(CreateAuthorDTO authorDTO, CancellationToken cancellation = default)
        {
            var createdAuthor = await _bookService.CreateAuthor(authorDTO,cancellation);
            if (createdAuthor == null) return BadRequest("There is another Author with this name");
            return CreatedAtAction(nameof(GetAuthorWithBooks), new { createdAuthor.Id, cancellation }, createdAuthor);
        }

        [HttpPost("CreateBook/{authorId}")]
        public async Task<IActionResult> CreateBook(int authorId,CreateBookDTO bookDTO,CancellationToken cancellation = default)
        {
            var createdBook = await _bookService.CreateBook(authorId,bookDTO,cancellation);
            if (createdBook == null) return NotFound("There isn't any Author having this id");

            return CreatedAtAction(nameof(GetBook),new {createdBook.Id, cancellation }, createdBook);
        }
    }
}
