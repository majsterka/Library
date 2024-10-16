using Datapac.Services;
using Datapac.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Datapac.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public BookController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        /// <summary>
        /// Get all books
        /// </summary>
        /// <returns>List of all books in the library</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookModel>>> GetAll()
        {
            return Ok(await _libraryService.GetAllBooksAsync());
        }

        /// <summary>
        /// Get book by Id
        /// </summary>
        /// <param name="isbn">ISBN - ID of a book</param>
        /// <returns>Book info</returns>
        /// <response code="404">Not found</response>
        [HttpGet("{isbn}")]
        public async Task<IActionResult> Get(string isbn)
        {
            return Ok(await _libraryService.GetBookAsync(isbn));
        }

        /// <summary>
        /// Get full book data
        /// </summary>
        /// <param name="isbn">ISBN - ID of a book</param>
        /// <returns>Book info</returns>
        /// <response code="404">Not found</response>
        [HttpGet("full/{isbn}")]
        public async Task<IActionResult> GetFull(string isbn)
        {
            return Ok(await _libraryService.GetBookFullAsync(isbn));
        }

        /// <summary>
        /// Create new book
        /// </summary>
        /// <param name="model">Data about new book</param>
        /// <returns>New book info</returns>
        /// <response code="400">Bad request</response>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookModel model)
        {
            return Ok(await _libraryService.CreateBookAsync(model));
        }

        /// <summary>
        /// Update existing book
        /// </summary>
        /// <param name="isbn">Book identificator - ISBN</param>
        /// <param name="model">New book info</param>
        [HttpPut("{isbn}")]
        public async Task<IActionResult> Update(string isbn, [FromBody] BookUpdateModel model)
        {
            return Ok(await _libraryService.UpdateBookAsync(isbn, model));
        }

        /// <summary>
        /// Delete existing book
        /// </summary>
        /// <param name="isbn"></param>
        [HttpDelete("{isbn}")]
        public async Task<OkResult> Delete(string isbn)
        {
            await _libraryService.DeleteBookAsync(isbn);

            return await Task.FromResult(Ok());
        }
    }
}
