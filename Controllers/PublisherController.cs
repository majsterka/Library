using Datapac.Services;
using Microsoft.AspNetCore.Mvc;

namespace Datapac.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : Controller
    {
        private readonly ILibraryService _libraryService;

        public PublisherController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        /// <summary>
        /// Get all Publishers
        /// </summary>
        /// <returns>List of all Publishers</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _libraryService.GetAllPublishersAsync());
        }
    }
}
