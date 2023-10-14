using Microsoft.AspNetCore.Mvc;
using CompanyFinderAPI.Models;

namespace CompanyFinderAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnalyzeCompanyController : Controller
    {
        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CurrentQuarterlyEarnings([FromForm] string function, [FromForm] string symbol)
        {
            return Ok();
        }
    }
}
