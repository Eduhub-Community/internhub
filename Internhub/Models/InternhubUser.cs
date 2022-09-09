using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Internhub.Models
{
    public class InternhubUser : IdentityUser
    {
        public string Name { get; set; }

        public string Organization { get; set; }
    }
}
