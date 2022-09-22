using Internhub.Models;

namespace Internhub.Repository.IServices
{
    /// <summary>
    /// Intership data Interface
    /// </summary>
    public interface IGetInternships
    {
        Task AddInternship(Internship internship, IFormFile logo);
        Task<List<Internship>> GetAllInternships();
        Task<Internship> GetInternshipById(Guid id);

        Task DeleteInternship(Internship internship);

        Task<Internship> EditInternship(Guid id);


    }
}
