using Microsoft.EntityFrameworkCore;

namespace Internhub.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)   
        {

        }
    }
}
