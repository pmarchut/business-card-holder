using BusinessCardHolder.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessCardHolder.ViewModels
{
    public class EmployeeIndexViewModel
    {
        public List<Employee> Employees { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }
        
        public string Telephone { get; set; }

        [Display(Name = "Mobile Telephone")]
        public string MobileTelephone { get; set; }

        public string Email { get; set; }
    }
}
