using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internhub.Models
{
    public class InternhubUser : IdentityUser
    {
        [Column("Full Name")]
        public string FullName { get; set; }

        [Column("Company Name")]
        public string CompanyName { get; set; }

        [Required]
        public bool IsCompany { get; set; }


        public string Resume { get; set; }
    }
}
