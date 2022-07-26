using Microsoft.AspNetCore.Mvc;

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
