using Datapac.Services;
using Microsoft.AspNetCore.Mvc;

namespace Datapac.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : Controller
    {
        private readonly ILibraryService _libraryService;

        public ArtistsController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        /// <summary>
        /// Get all artists - authors, illustrators, translators
        /// </summary>
        /// <returns>List of all artists</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _libraryService.GetAllArtistsAsync());
        }
    }
}
