using Datapac.Services;
using Microsoft.AspNetCore.Mvc;

namespace Datapac.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExemplarController : Controller
    {
        private readonly ILibraryService _libraryService;

        public ExemplarController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        /// <summary>
        /// Get all Exemplars
        /// </summary>
        /// <returns>List of all Exemplars</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _libraryService.GetAllExemplarsAsync());
        }
    }
}
