using Datapac.Services;
using Microsoft.AspNetCore.Mvc;

namespace Datapac.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : Controller
    {
        private readonly ILibraryService _libraryService;

        public LanguageController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        /// <summary>
        /// Get all Languages
        /// </summary>
        /// <returns>List of all Languages</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _libraryService.GetAllLanguagesAsync());
        }
    }
}
