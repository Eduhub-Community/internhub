using Internhub.Models;
using Internhub.Models.Static;
using Internhub.Repository.IServices;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace Internhub.Areas.Company.Controllers
{
    [Area("Company")]
    public class InternshipController : Controller
    {
        private readonly ILogger<InternshipController> _logger;
        private readonly ICountry country;
        private readonly IGetInternships internships;
        private readonly UserManager<InternhubUser> _userManager;


        public InternshipController(ILogger<InternshipController> logger, ICountry country,IGetInternships internships,UserManager<InternhubUser> userManager)
        {
            _logger = logger;
            this.country = country; 
            this.internships = internships;
            this._userManager = userManager;    

        }
        public IActionResult Post()
        {
            //shows the name of Countries A-z in the View
            ViewBag.Country = new SelectList(country.CountryNames());
            //Shows the Jobtrype in the view e.g remote...
            ViewBag.JobType = new SelectList(Enum.GetNames(typeof(JobType.Job)).ToList());
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Post")]
        public IActionResult AddPost([ModelBinder]Internship internship, IFormFile logo)
        {
            //Gets the current loggedIn user Id
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            internship.InternshipId = Guid.NewGuid();
            internship.Id = userId;
            internship.DateCreated = DateTime.UtcNow;
            if (ModelState.IsValid)
            {
                internships.AddInternship(internship, logo);
                TempData["AddInternship"] = "Internship added successfully";
                return RedirectToAction("List");
            }
            ModelState.AddModelError(string.Empty, "Complete the form");
             return View(internship);
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
