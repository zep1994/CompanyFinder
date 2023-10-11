using CompanyFinderAPI.Data;
using CompanyFinderAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CompanyFinderAPI.ViewModels;
using System.Globalization;

namespace CompanyFinderAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WatchListsController : Controller
    {
        private readonly AppDbContext _dbContext;

        public WatchListsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            var watchLists = _dbContext.WatchLists.ToList();
            return View(watchLists);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            // Fetch companies and watchlists for the view
            ViewBag.Companies = new MultiSelectList(_dbContext.Companies, "Id", "Name");
            ViewBag.WatchLists = new SelectList(_dbContext.WatchLists, "Id", "Name");
            return View();
        }

        [HttpPost("Create")]
        public IActionResult Create([FromForm] WatchListsViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Create a new WatchList
                var newWatchLists = new WatchLists
                {
                    Name = model.Name,
                    Description = model.Description,
                    Sector = model.Sector,
                    Industry = model.Industry
                    // Add other properties as needed
                };

                // Associate selected companies with the new WatchList
                foreach (var companyId in model.SelectedCompanyIds)
                {
                    var company = _dbContext.Companies.Find(companyId);
                    if (company != null)
                    {
                        newWatchLists.Companies.Add(company);
                    }
                    else
                    {
                        return NoContent();
                    }
                }

                _dbContext.WatchLists.Add(newWatchLists);
                _dbContext.SaveChanges();

                return Redirect("Index");
                
            }

            // If validation fails, fetch companies again for the view
            ViewBag.Companies = new MultiSelectList(_dbContext.Companies, "Id", "Name", model.SelectedCompanyIds);
            ViewBag.WatchLists = new SelectList(_dbContext.WatchLists, "Id", "Name");


            return NotFound();

        }
    }


        //[HttpPost("deletewatchlist")]
        //public IActionResult DeleteCompany(WatchList watchList)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _dbContext.WatchLists.Add(watchList);
        //        _dbContext.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(watchList);
        //}
    }

