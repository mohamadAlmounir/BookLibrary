using BooksLibrary.core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : Controller
    {
        private readonly IUnitOfWork _AuthorUnitOfWork;

        public AuthorController(IUnitOfWork unitOfWork)
        {
            _AuthorUnitOfWork = unitOfWork;
        }

        [HttpGet("GetAllAuthors")]
        public async Task<IActionResult> GetAllAuthors()
        {
            var result = await _AuthorUnitOfWork.Author.GetAll();
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpGet("FindAuthorByName")]
        public async Task<IActionResult> FindAuthorByName([FromBody]string authorName)
        {
            var result = await _AuthorUnitOfWork.Author.FindByName(authorName);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpGet("FindAuthorById/{id}")]
        public async Task<IActionResult> FindAuthorById(int id)
        {
            var result = await _AuthorUnitOfWork.Author.Find(id);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);

        }


        //[Authorize(Roles ="Admin")]
        [HttpPost("AddAuthor")]
        public async Task<IActionResult> AddAuthor([FromBody] string authorName)
        {
            var result = await _AuthorUnitOfWork.Author.AddNew(authorName);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            await _AuthorUnitOfWork.CompleteAsync();
            return Ok(result);
        }
    }
}
