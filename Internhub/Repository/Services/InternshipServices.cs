using Internhub.Abstract;
using Internhub.Data;
using Internhub.Models;
using Internhub.Repository.IServices;
using System.Runtime.CompilerServices;

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

        Task<List<Internship>> IGetInternships.GetAllInternships()
        {
            throw new NotImplementedException();
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
    }
}
