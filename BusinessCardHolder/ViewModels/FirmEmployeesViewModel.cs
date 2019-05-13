using BusinessCardHolder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessCardHolder.ViewModels
{
    public class FirmEmployeesViewModel
    {
        public List<Employee> Employees { get; set; }
        public string PageTitle { get; set; }
        public int Id { get; set; }
    }
}
