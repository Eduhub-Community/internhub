using Internhub.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Internhub.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)   
        {

        }
        public DbSet<Internship> Internship { get; set; }
        public DbSet<InternhubUser> InternhubUser { get; set; }
    }
}
