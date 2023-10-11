using CompanyFinderAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace CompanyFinderAPI.Controllers
{
    public class CompanyController : Controller
    {
        private const string apiKey = "demo"; // Replace with your AlphaVantage API key
        private readonly AppDbContext _context;


        public IActionResult Index()
        {
            return View();
        }
    }
}
