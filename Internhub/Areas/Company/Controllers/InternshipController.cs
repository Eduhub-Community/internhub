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

        public InternshipController(ILogger<InternshipController> logger)
        {
            _logger = logger;
        }
        public IActionResult Post()
        {
            ViewBag.Country = new SelectList(Enum.GetNames(typeof(Country.List)));
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
