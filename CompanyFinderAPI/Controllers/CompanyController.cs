using CompanyFinderAPI.Data;
using CompanyFinderAPI.Models;
using CompanyFinderAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace CompanyFinderAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IHttpClientFactory _clientFactory;
        private readonly string baseUrl = "https://www.alphavantage.co/query?";
        private readonly string apiKey = "FLW875WO7JXEYS29";
        public string function;
        


        public CompanyController(AppDbContext dbContext, IHttpClientFactory clientFactory)
        {
            _dbContext = dbContext;
            _clientFactory = clientFactory;
        }

        [HttpGet]
        [Route("allcompanies")]
        public async Task<IActionResult> AllCompanies()
        {
            var companies = await _dbContext.Companies.ToListAsync();
            return View("allcompanies", companies); 
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ShowCompany(int id)
        {
            var company = await _dbContext.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound("Company not found.");
            }

            return View("ShowCompany", company); 
        }

        [HttpPost]
        [Route("savecompany")]
        public async Task<IActionResult> SaveCompany([FromForm] Company company)
        {
            if (company == null)
            {
                return BadRequest("Invalid company data.");
            }

            // Save the company to the database
            _dbContext.Companies.Add(company);
            await _dbContext.SaveChangesAsync();

            return View("ShowCompany", company);
        }

        [HttpPost]
        [Route("deletecompany/{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var company = await _dbContext.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound("Company not found.");
            }

            _dbContext.Companies.Remove(company);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("allcompanies");
        }

        public IActionResult Create()
        {
            try
            {
                // Fetch available companies to display in a checkbox list
                var companies = _dbContext.Companies.ToList(); 
                ViewBag.Companies = new MultiSelectList(companies, "Id", "Name");

                return View(new WatchListsViewModel());
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
                return RedirectToAction("Error"); 
            }
        }


        [HttpGet]
        [Route("Search")]
        public IActionResult Search()
        {
            return View("Search");
        }

        [HttpPost]
        [Route("Search")]
        public async Task<IActionResult> Search([FromForm] string symbol)
        {
            var apiKey = "FLW875WO7JXEYS29";
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://www.alphavantage.co/query?function=OVERVIEW&symbol={symbol}&apikey={apiKey}");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<Company>(responseStream);

                // Return the data to the view for displaying in a form
                return View("GetCompanyOverview", data); // Assumes you have a corresponding View named "GetCompanyOverview"
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("Fundamentals")]
        public async Task<IActionResult> Fundamentals([FromForm] string function, [FromForm] string symbol)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}function={function}&symbol={symbol}&apikey={apiKey}");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<Fundamentals>(responseStream);

                return View("Fundamentals", data); 
            }
            return BadRequest();
        }
    }
}


