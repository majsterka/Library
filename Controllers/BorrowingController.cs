using Datapac.Services;
using Datapac.Services.ViewModels;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.AspNetCore.Mvc;

namespace Datapac.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowingController : Controller
    {
        private readonly ILibraryService _libraryService;

        public BorrowingController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        /// <summary>
        /// Get all current borrowings, not returned
        /// </summary>
        /// <returns>List of all borrowings</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _libraryService.GetAllBorrowingsAsync());
        }

        /// <summary>
        /// Create new borrowing
        /// </summary>
        /// <param name="userId">User</param>
        /// <param name="exemplarId">Exemplar of book</param>
        /// <returns>Created borrowing</returns>
        [HttpPost]
        public async Task<IActionResult> Create(int userId, int exemplarId)
        {
            return Ok(await _libraryService.CreateBorrowingAsync(userId, exemplarId));
        }

        /// <summary>
        /// Book returning
        /// </summary>
        /// <param name="exemplarIds">Exeplar ids, returned books</param>
        /// <returns>Pdf</returns>
        [HttpPost("return")]
        public async Task<IActionResult> ReturnBorrowings(int[] exemplarIds)
        {
            List<ReturnsModel> returns = await _libraryService.ReturnBorrowingsAsync(exemplarIds);

            return File(CreatePdf(returns), "application/pdf", "confirmation_of_return.pdf");
        }

        private byte[] CreatePdf(List<ReturnsModel> returns)
        {
            var stream = new MemoryStream();
            var writer = new PdfWriter(stream);
            var pdf = new PdfDocument(writer);
            var document = new Document(pdf);

            document.Add(new Paragraph("Potvrdenie o vrátení"));
            List list = new List()
            .SetSymbolIndent(12)
            .SetListSymbol("\u2022");
            foreach (var item in returns)
            {
                list.Add(new ListItem($"{item.Name}: {item.BookName}"));
            }
            document.Add(list);

            document.Add(new Paragraph("Podpis:"));

            document.Close();

            return stream.ToArray();
        }
    }
}
