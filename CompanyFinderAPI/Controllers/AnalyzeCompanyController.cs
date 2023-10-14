using Microsoft.AspNetCore.Mvc;
using CompanyFinderAPI.Models;

namespace CompanyFinderAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnalyzeCompanyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> CurrentQuarterlyEarnings(Company company)
        {
            return Ok();
        }
    }
}
