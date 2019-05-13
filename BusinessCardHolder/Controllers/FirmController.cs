using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessCardHolder.Models;
using BusinessCardHolder.Repository;
using Microsoft.AspNetCore.Mvc;
using BusinessCardHolder.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BusinessCardHolder.Controllers
{
    [Route("[controller]")]
    [Route("")]
    public class FirmController : Controller
    {
        public IFirmRepository FirmRepo { get; set; }
        public IEmployeeRepository EmployeeRepo { get; set; }

        public FirmController(IFirmRepository _firmRepo, IEmployeeRepository _employeeRepo)
        {
            FirmRepo = _firmRepo;
            EmployeeRepo = _employeeRepo;
        }

        [HttpGet]
        [Route("")]
        [Route("Index")]
        public async Task<IActionResult> Index(string name, string NIP, string address, string city, 
            string postalCode, string telephone, string email)
        {
            List<Firm> firmList = await FirmRepo.GetAll();

            if (!string.IsNullOrEmpty(name))
                firmList = firmList.Where(n => n.Name.Contains(name)).ToList();

            if (!string.IsNullOrEmpty(NIP))
                firmList = firmList.Where(n => n.NIP.Contains(NIP)).ToList();

            if (!string.IsNullOrEmpty(address))
                firmList = firmList.Where(a => a.Address.Contains(address)).ToList();

            if (!string.IsNullOrEmpty(city))
                firmList = firmList.Where(c => c.City.Contains(city)).ToList();

            if (!string.IsNullOrEmpty(postalCode))
                firmList = firmList.Where(p => p.PostalCode.Contains(postalCode)).ToList();

            if (!string.IsNullOrEmpty(telephone))
                firmList = firmList.Where(t => t.Telephone.Contains(telephone)).ToList();

            if (!string.IsNullOrEmpty(email))
                firmList = firmList.Where(e => e.Email.Contains(email)).ToList();

            FirmIndexViewModel firmIndexViewModel = new FirmIndexViewModel()
            {
                Firms = firmList
            };

            return View(firmIndexViewModel);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            Firm item = await FirmRepo.Find(id);
            if (item == null)
                return RedirectToAction("Index");

            return View(item);
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(Firm item)
        {
            if (item != null && ModelState.IsValid)
            {
                await FirmRepo.Add(item);
                return RedirectToAction("Details", new { id = item.Id });
            }

            return View();
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            Firm model = await FirmRepo.Find(id);

            if (model == null)
                return RedirectToAction("Index");

            return View(model);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, Firm item)
        {
            Firm firm = await FirmRepo.Find(id);

            if (firm != null && ModelState.IsValid)
            {
                await FirmRepo.Update(item);
                return RedirectToAction("Details", new { id = firm.Id });
            }

            return View(firm);
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Firm firm = await FirmRepo.Find(id);

            if (firm == null)
                return RedirectToAction("Index");

            return View(firm);
        }

        [HttpPost]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Firm firm = await FirmRepo.Find(id);

            if (firm == null)
                return RedirectToAction("Index");

            await FirmRepo.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Employees/{id}")]
        public async Task<IActionResult> Employees(int id)
        {
            List<Employee> employeeList = await EmployeeRepo.GetFirmEmployees(id);
            Firm firm = await FirmRepo.Find(id);

            FirmEmployeesViewModel firmEmployeesViewModel = new FirmEmployeesViewModel()
            {
                Employees = employeeList,
                PageTitle = firm.Name + "'s Employees",
                Id = firm.Id
            };

            return View(firmEmployeesViewModel);
        }
    }
}
