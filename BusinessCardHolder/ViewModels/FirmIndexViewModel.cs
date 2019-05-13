using BusinessCardHolder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessCardHolder.ViewModels
{
    public class FirmIndexViewModel
    {
        public List<Firm> Firms { get; set; }
        public string Name { get; set; }
        public string NIP { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
    }
}
