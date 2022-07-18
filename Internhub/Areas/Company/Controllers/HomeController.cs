using Microsoft.AspNetCore.Mvc;

namespace Internhub.Areas.Company.Controllers
{
    [Area("Company")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
