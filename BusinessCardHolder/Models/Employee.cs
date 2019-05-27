using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessCardHolder.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(55, ErrorMessage = "First Name cannot be longer than 55 characters.")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(1075, ErrorMessage = "Last Name cannot be longer than 1075 characters.")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Job Title")]
        [StringLength(250, ErrorMessage = "Job Title cannot be longer than 250 characters.")]
        public string JobTitle { get; set; }

        [Required]
        [RegularExpression(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$", ErrorMessage = "Invalid Telephone format.")]
        [StringLength(18, ErrorMessage = "Telephone cannot be longer than 18 characters.")]
        public string Telephone { get; set; }

        [Required]
        [RegularExpression(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$", ErrorMessage = "Invalid Telephone format.")]
        [Display(Name = "Mobile Telephone")]
        [StringLength(18, ErrorMessage = "Mobile telephone cannot be longer than 18 characters.")]
        public string MobileTelephone { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email format.")]
        [StringLength(345, ErrorMessage = "Email cannot be longer than 345 characters.")]
        public string Email { get; set; }

        [ForeignKey("FirmId")]
        public Firm Firm { get; set; }

        [Required]
        [Display(Name = "Firm")]
        public int FirmId { get; set; }
    }
}
