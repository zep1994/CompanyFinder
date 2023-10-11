using CompanyFinderAPI.Data;
using CompanyFinderAPI.Models;
using CompanyFinderAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            return View("allcompanies", companies);  // Assuming you have a corresponding View named "AllCompanies"
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
            return View("ShowCompany", company);  // Assuming you have a corresponding View named "ShowCompany"
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
                var companies = _dbContext.Companies.ToList(); // Assuming Companies is DbSet<Company> in your DbContext
                ViewBag.Companies = new MultiSelectList(companies, "Id", "Name");

                return View(new WatchListsViewModel());
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                Console.WriteLine(ex.Message);
                return RedirectToAction("Error"); // Redirect to an error page or handle the error as needed
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
            var apiKey = "demo";
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://www.alphavantage.co/query?function=OVERVIEW&symbol={symbol}&apikey={apiKey}");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<Company>(responseStream);

                // Return the data to the view for displaying in a form
                return View(); // Assumes you have a corresponding View named "GetCompanyOverview"
            }
            return BadRequest();
        }

        //[HttpPost]
        //public IActionResult Create(Company model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Create a new company
        //        var newCompany = new Company
        //        {
        //            Symbol = model.Symbol,
        //            Name = model.Name,
        //            // ... other properties ...
        //        };

        //        // Associate the new company with the selected WatchList
        //        var selectedWatchList = _dbContext.WatchLists.Find(model.WatchListId);
        //        if (selectedWatchList != null)
        //        {
        //            newCompany. WatchList = selectedWatchList;
        //        }

        //        _dbContext.Companies.Add(newCompany);
        //        _dbContext.SaveChanges();

        //        return RedirectToAction("Index");
        //    }

        //    // If validation fails, fetch WatchLists and companies again for the view
        //    ViewBag.WatchLists = new SelectList(_dbContext.WatchLists, "Id", "Name", model.WatchListId);
        //    ViewBag.Companies = new MultiSelectList(_dbContext.Companies, "Id", "Name", model.SelectedCompanyIds);

        //    return View(model);
    }

}


