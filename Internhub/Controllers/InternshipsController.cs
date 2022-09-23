using Internhub.Models;
using Internhub.Repository.IServices;
using Internhub.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Internhub.Controllers
{
    public class InternshipsController : Controller
    {
        private readonly ILogger<InternshipsController> _logger;
        private readonly IGetInternships internships;

        //List<Internship> intershipsSession = SessionExtensions.SetString();
        public InternshipsController(ILogger<InternshipsController> logger,IGetInternships internships)
        {
            _logger = logger;
            this.internships = internships;
        }
        public IActionResult Index()
        {
           // var posts = internships.GetAllInternships();
           var posts = HttpContext.Session.Get<List<Internship>>("internships") ?? new List<Internship>();
            return View();
        }
        public IActionResult Description()
        {
            return View();
        }

        public IActionResult Applied()
        {
            return View();
        }
    }
}
