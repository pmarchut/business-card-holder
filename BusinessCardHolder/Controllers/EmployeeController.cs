using BusinessCardHolder.Models;
using BusinessCardHolder.Repository;
using BusinessCardHolder.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessCardHolder.Controllers
{
    [Route("Employee")]
    public class EmployeeController : Controller
    {
        public IEmployeeRepository EmployeeRepo { get; set; }
        public IFirmRepository FirmRepo { get; set; }

        public EmployeeController(IEmployeeRepository _employeeRepo, IFirmRepository _firmRepo)
        {
            EmployeeRepo = _employeeRepo;
            FirmRepo = _firmRepo;
        }

        [HttpGet]
        [Route("")]
        [Route("Index")]
        public async Task<IActionResult> Index(string firstName, string lastName, string jobTitle,
            string telephone, string mobileTelephone, string email)
        {
            List<Employee> employeeList = await EmployeeRepo.GetAll();

            if (!string.IsNullOrEmpty(firstName))
                employeeList = employeeList.Where(f => f.FirstName.Contains(firstName)).ToList();

            if (!string.IsNullOrEmpty(lastName))
                employeeList = employeeList.Where(l => l.LastName.Contains(lastName)).ToList();

            if (!string.IsNullOrEmpty(jobTitle))
                employeeList = employeeList.Where(j => j.JobTitle.Contains(jobTitle)).ToList();

            if (!string.IsNullOrEmpty(telephone))
                employeeList = employeeList.Where(t => t.Telephone.Contains(telephone)).ToList();

            if (!string.IsNullOrEmpty(mobileTelephone))
                employeeList = employeeList.Where(m => m.MobileTelephone.Contains(mobileTelephone)).ToList();

            if (!string.IsNullOrEmpty(email))
                employeeList = employeeList.Where(e => e.Email.Contains(email)).ToList();

            EmployeeIndexViewModel employeeIndexViewModel = new EmployeeIndexViewModel()
            {
                Employees = employeeList
            };

            return View(employeeIndexViewModel);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            Employee item = await EmployeeRepo.Find(id);
            if (item == null)
                return RedirectToAction("../Firm/Index");

            return View(item);
        }

        [HttpGet]
        [Route("Create")]
        public async Task<IActionResult> Create()
        {
            ViewBag.FirmId = new SelectList(await FirmRepo.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(Employee item)
        {
            if (item != null && ModelState.IsValid)
            {
                await EmployeeRepo.Add(item);
                return RedirectToAction("Details", new { id = item.Id });
            }

            ViewBag.FirmId = new SelectList(await FirmRepo.GetAll(), "Id", "Name", item.FirmId);
            return View(item);
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            Employee model = await EmployeeRepo.Find(id);

            if (model == null)
                return RedirectToAction("../Firm/Index");

            ViewBag.FirmId = new SelectList(await FirmRepo.GetAll(), "Id", "Name", model.FirmId);
            return View(model);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, Employee item)
        {
            Employee employee = await EmployeeRepo.Find(id);

            if (employee != null && ModelState.IsValid)
            {
                await EmployeeRepo.Update(item);
                return RedirectToAction("Details", new { id = employee.Id });
            }

            ViewBag.FirmId = new SelectList(await FirmRepo.GetAll(), "Id", "Name", employee.FirmId);
            return View(employee);
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Employee employee = await EmployeeRepo.Find(id);

            if (employee == null)
                return RedirectToAction("Index");

            return View(employee);
        }

        [HttpPost]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Employee employee = await EmployeeRepo.Find(id);

            if (employee == null)
                return RedirectToAction("Index");

            await EmployeeRepo.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
