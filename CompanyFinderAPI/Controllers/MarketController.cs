using Microsoft.AspNetCore.Mvc;

namespace CompanyFinderAPI.Controllers
{
    public class MarketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
