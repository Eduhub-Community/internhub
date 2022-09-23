using Internhub.Abstract;
using Internhub.Data;
using Internhub.Models;
using Internhub.Repository.IServices;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Internhub.Repository.Services
{
    public class InternshipServices : ImageAbstract,IGetInternships
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _env;

        public InternshipServices(DataContext dataContext, IWebHostEnvironment env)
        {
            _dataContext = dataContext;
            _env = env; 
        }
    
        async Task IGetInternships.AddInternship(Internship internship, IFormFile logo)
        {
            if(logo != null)
            {
                Func<IFormFile, string> logoUrl = AddImage;
                internship.ComapnyLogo = logoUrl(logo);
            }
            await _dataContext.Internship.AddAsync(internship);
            await _dataContext.SaveChangesAsync();
        }

        Task IGetInternships.DeleteInternship(Internship internship)
        {
            throw new NotImplementedException();
        }

        Task<Internship> IGetInternships.EditInternship(Guid id)
        {
            throw new NotImplementedException();
        }

        List<Internship> IGetInternships.GetAllCompanyInternships(InternhubUser user)
        {
            List<Internship> intershhips = user.Jobs ?? new List<Internship>();
            return intershhips;
        }

        Task<Internship> IGetInternships.GetInternshipById(Guid id)
        {
            throw new NotImplementedException();
        }

        public override string AddImage(IFormFile img)
        {
            //Getting the Image upload from server converuing to a url
            var name = Path.Combine(_env.WebRootPath + "/logo", Path.GetFileName(img.FileName));
            img.CopyTo(new FileStream(name, FileMode.Create));
            string url = $"logo/{img.FileName}";
            return url;
        }

        /// <summary>
        /// This method accept a delegate method that returns a string
        /// to get the user's data
        /// </summary>
        /// <param name="userIdMethod"></param>
        /// <returns></returns>
        Task<InternhubUser> IGetInternships.GetCompanyUser(Func<string> userIdMethod)
        {
            string userId = userIdMethod(); 
            var user = _dataContext.InternhubUser.Include(c => c.Jobs).Where(d => d.Id == userId).FirstOrDefaultAsync();
            return user;
        }

        Task<List<Internship>> IGetInternships.GetAllInternships()
        {
            return _dataContext.Internship.ToListAsync();
        }
    }
}
