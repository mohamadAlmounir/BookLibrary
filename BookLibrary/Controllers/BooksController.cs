using BooksLibrary.core;
using BooksLibrary.core.Dtos;
using BooksLibrary.EF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly IUnitOfWork _BooksUnitOfWork;
        public BooksController(IUnitOfWork booksUnitOfWork)
        {
            _BooksUnitOfWork = booksUnitOfWork;
        }

        [HttpGet("FindBook/{id}")]
        public async Task<IActionResult> FindBook(int id)
        {
            var result = await _BooksUnitOfWork.Book.Find(id);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);

        }

        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            var result = await _BooksUnitOfWork.Book.GetAll();
            return Ok(result);
        }

        [HttpGet("FindBookByTitle")]
        public async Task<IActionResult> FindBookByTitle([FromBody]string title)
        {
            var result = _BooksUnitOfWork.Book.FindByTitle(title).Result;
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpGet("GetAllBooksByGenre/{genreId}")]
        public async Task<IActionResult> GetAllBooksByGenre(int genreId)
        {
            var result = _BooksUnitOfWork.Book.FindAllByGenre(genreId).Result;
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpGet("GetAllBooksByAuthor")]
        public async Task<IActionResult> GetAllBooksByAuthor([FromBody]string authorName)
        {
            var result = _BooksUnitOfWork.Book.FindAllByAuthor(authorName).Result;
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }


        [Authorize(Roles ="Admin")]
        [HttpPost("AddNewBook")]
        public async Task<IActionResult> AddNewBook([FromBody] BooksLibrary.core.Dtos.BookDto newBook)
        {
            var result = await _BooksUnitOfWork.Book.AddNew(newBook);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            await _BooksUnitOfWork.CompleteAsync();
            return Ok(result);
        }


        [Authorize(Roles ="Admin")]
        [HttpPut("UpdateBook/{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] BookDto updatedBook)
        {
            var result = await _BooksUnitOfWork.Book.Update(id, updatedBook);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            await _BooksUnitOfWork.CompleteAsync();
            return Ok(result);
        }


        [Authorize(Roles ="Admin")]
        [HttpDelete("DeleteBook/{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await _BooksUnitOfWork.Book.Delete(id);
            if (!result.Success)
            {
                return NotFound(result);
            }
            await _BooksUnitOfWork.CompleteAsync();
            return Ok(result);
        }
    }
}
