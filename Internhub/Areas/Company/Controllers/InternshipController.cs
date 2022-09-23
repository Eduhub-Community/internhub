using Internhub.Models;
using Internhub.Models.Static;
using Internhub.Repository.IServices;
using Internhub.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace Internhub.Areas.Company.Controllers
{
    [Area("Company")]
    [Authorize(Roles ="Company")]

    public class InternshipController : Controller
    {
        private readonly ILogger<InternshipController> _logger;
        private readonly ICountry country;
        private readonly IGetInternships internships;
        private readonly UserManager<InternhubUser> _userManager;
        public List<Internship> internshipsSession = new List<Internship>();

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

        /// <summary>
        /// Mecthod6 that adds the internship to database
        /// </summary>
        /// <param name="internship"></param>
        /// <param name="logo"></param>
        /// <returns></returns>
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
                internshipsSession = HttpContext.Session.Get<List<Internship>>("internships") ?? new List<Internship>();
                //add the internship to database
                internships.AddInternship(internship, logo);
                internshipsSession.Add(internship);
                HttpContext.Session.Set("internships",internshipsSession);  
                //Send to the notification message in Javascript
                TempData["AddInternship"] = "You have successfully Posted an Internship, checkout for the Students Aplications";

                return RedirectToAction("List");
            }
            ModelState.AddModelError(string.Empty, "Complete the form");
             return View(internship);
        }
        /// <summary>
        /// Method that shows the list of interships 
        /// for the individual account
        /// </summary>
        /// <returns></returns>
        public IActionResult List()
        {
            //Gets the company user data
            var user = internships.GetCompanyUser(GetUserid).Result;
            //returns the Internships under the company user
            var posts = internships.GetAllCompanyInternships(user);
            return View(posts);
        }

        public IActionResult Resumes()
        {
            return View();
        }

        /// <summary>
        /// Get the current user id
        /// </summary>
        /// <returns></returns>
        private string GetUserid()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
