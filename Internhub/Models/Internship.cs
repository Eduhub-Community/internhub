using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internhub.Models
{
    /// <summary>
    /// Intership modules
    /// </summary>
    public class Internship
    {
        [Key]
        public Guid InternshipId { get; set; }

        public string Id { get; set; }
        [ForeignKey("Id")]
        public InternhubUser CompanyUser { get; set; }

        [Required]
        [Column("Job Title")]
        public string JobTitle { get; set; }

        [Required]
        [Column("Job Description")]
        public string JobDescription { get; set; }

        [Required]
        [Column("NOP")]
        public int NOP { get; set; }

        [Required]
        [Column("Qualification/Education")]
        public string Qualification { get; set; }

        [Required]
        [Column("Experience")]
        [MaxLength(20,ErrorMessage ="Characters too long")]
        public string Experience { get; set; }

        [Required]
        [Column("Specialization")]
        public string Specialization { get; set; }

        [Column("LastDateToApply")]
        [DataType(DataType.Date)]
        public string LastDateToApply { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Column("Salary")]
        [DataType(DataType.Currency)]
        public string Salary { get; set; }

        [Required]
        [Column("Job Type")]
        public string JobType { get; set; }

        [Required]
        [Column("Company name")]
        public string CompanyName { get; set; }

        [Column("Comapny Logo")]
        public string ComapnyLogo { get; set; }

        [Column("Website")]
        [DataType(DataType.Url)]
        public string Website { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(60,ErrorMessage ="too Long")]
        public string Address { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string State { get; set; }

    }
}
