using Datapac.Services;
using Microsoft.AspNetCore.Mvc;

namespace Datapac.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EbookController : Controller
    {
        private readonly ILibraryService _libraryService;

        public EbookController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        /// <summary>
        /// Get all Ebooks
        /// </summary>
        /// <returns>List of all Ebooks</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _libraryService.GetAllEbooksAsync());
        }
    }
}
