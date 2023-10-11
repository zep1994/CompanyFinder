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

            return StatusCode(200);
        }
    }
}

