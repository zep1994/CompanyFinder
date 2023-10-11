using CompanyFinderAPI.Data;
using CompanyFinderAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyFinderAPI.Controllers
{
    public class CompanyController : Controller
    {
        private readonly AppDbContext _dbContext;

        public CompanyController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("allcompanies")]
        public async Task<IActionResult> AllCompanies()
        {
            var companies = await _dbContext.Companies.ToListAsync();
            return View(companies);  // Assuming you have a corresponding View named "AllCompanies"
        }

        [HttpGet]
        [Route("company/{id}")]
        public async Task<IActionResult> ShowCompany(int id)
        {
            var company = await _dbContext.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound("Company not found.");
            }
            return View(company);  // Assuming you have a corresponding View named "ShowCompany"
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

            return View("CompanyDetails", company);
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

            return RedirectToAction("Index");
        }

    }
}

