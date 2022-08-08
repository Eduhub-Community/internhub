using Internhub.Models;
using Internhub.Models.Static;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Internhub.Areas.Company.Controllers
{
    [Area("Company")]
    public class InternshipController : Controller
    {
        private readonly ILogger<InternshipController> _logger;
        private readonly ICountry country;

        public InternshipController(ILogger<InternshipController> logger, ICountry country)
        {
            _logger = logger;            this.country = country; 

        }
        public IActionResult Post()
        {
            ViewBag.Country = new SelectList(country.CountryNames());
            return View();
        }
        public IActionResult List()
        {
            return View();
        }
        public IActionResult Resumes()
        {
            return View();
        }
    }
}
