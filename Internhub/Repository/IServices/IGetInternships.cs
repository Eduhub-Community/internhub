using Internhub.Models;

namespace Internhub.Repository.IServices
{
    /// <summary>
    /// Intership data Interface
    /// </summary>
    public interface IGetInternships
    {
        Task<InternhubUser> GetCompanyUser(Func<string> userIdMethod);

        Task AddInternship(Internship internship, IFormFile logo);

        List<Internship> GetAllCompanyInternships(InternhubUser user);
        Task<List<Internship>> GetAllInternships();

        Task<Internship> GetInternshipById(Guid id);

        Task DeleteInternship(Internship internship);

        Task<Internship> EditInternship(Guid id);


    }
}
