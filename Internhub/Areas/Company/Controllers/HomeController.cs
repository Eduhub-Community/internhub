using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Internhub.Areas.Company.Controllers
{
    [Area("Company")]
    [Authorize(Roles ="Company")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
