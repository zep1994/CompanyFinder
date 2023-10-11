using CompanyFinderAPI.Data;
using CompanyFinderAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CompanyFinderClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly AppDbContext _dbContext;


        public HomeController(IHttpClientFactory clientFactory, AppDbContext dbContext)
        {
            _clientFactory = clientFactory;
            _dbContext = dbContext;
        }

        //List ALL

        public async Task<IActionResult> Home()
        {
            var companies = await _dbContext.Companies.ToListAsync();
            var watchLists = await _dbContext.WatchLists.ToListAsync();

            var model = new Tuple<List<Company>, List<WatchLists>>(companies, watchLists);

            return View("Home", model);
            //var companies = await _dbContext.Companies.ToListAsync();
            //return View(companies);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}