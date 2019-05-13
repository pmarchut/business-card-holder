using BusinessCardHolder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessCardHolder.ViewModels
{
    public class EmployeeIndexViewModel
    {
        public List<Employee> Employees { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }    
        public string Telephone { get; set; }
        public string MobileTelephone { get; set; }
        public string Email { get; set; }
    }
}
