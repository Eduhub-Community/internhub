using Microsoft.AspNetCore.Identity;

namespace Internhub.Models
{
    public class InternhubUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
