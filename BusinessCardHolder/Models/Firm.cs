using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessCardHolder.Models
{
    public class Firm
    {
        public int Id { get; set; }

        [Required]
        [StringLength(155, ErrorMessage = "Name cannot be longer than 155 characters.")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^((\d{3}[- ]\d{3}[- ]\d{2}[- ]\d{2})|(\d{3}[- ]\d{2}[- ]\d{2}[- ]\d{3}))$", ErrorMessage = "Invalid NIP format.")]
        [StringLength(13, ErrorMessage = "NIP cannot be longer than 13 characters.")]
        public string NIP { get; set; }

        [Required]
        [StringLength(105, ErrorMessage = "Address cannot be longer than 105 characters.")]
        public string Address { get; set; }

        [Required]
        [StringLength(180, ErrorMessage = "City's name cannot be longer than 180 characters.")]
        public string City { get; set; }

        [Required]
        [Display(Name ="Postal Code")]
        [RegularExpression(@"^([0-9]|\-)*", ErrorMessage = "Invalid Postal Code format.")]
        [StringLength(80, ErrorMessage = "Postal cannot be longer than 80 characters.")]
        public string PostalCode { get; set; }

        [Required]
        [RegularExpression(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$", ErrorMessage = "Invalid Telephone format.")]
        [StringLength(18, ErrorMessage = "Telephone cannot be longer than 18 characters")]
        public string Telephone { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email format.")]
        [StringLength(345, ErrorMessage = "Email cannot be longer than 345 characters.")]
        public string Email { get; set; }

        public string Notes { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
