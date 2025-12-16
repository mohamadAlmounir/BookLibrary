using BooksLibrary.core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : Controller
    {
        private readonly IUnitOfWork _GenreUnitOfWork;

        public GenreController(IUnitOfWork unitOfWork)
        {
            _GenreUnitOfWork = unitOfWork;
        }

        [HttpGet("GetAllGenres")]
        public async Task<IActionResult> GetAllGenres()
        {
            var result = await _GenreUnitOfWork.genre.GetAll();
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }   

        [HttpGet("FindById/{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            var result = await _GenreUnitOfWork.genre.Find(id);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(new {Succsess=result.Success,GenreName=result.Data.Name,Message=result.Message });
        }
        //[Authorize(Roles ="Admin")]
        [HttpPost("AddGenre")]
        public async Task<IActionResult> AddGenre([FromBody] string genreName)
        {
            var result = await _GenreUnitOfWork.genre.AddNew(genreName);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            await _GenreUnitOfWork.CompleteAsync();
            return Ok(result);
        }
    }
}
