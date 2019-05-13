using BusinessCardHolder.Contexts;
using BusinessCardHolder.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessCardHolder.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public IConfiguration _config;

        BusinessCardHolderContext _context;

        public EmployeeRepository(IConfiguration config, BusinessCardHolderContext context)
        {
            _config = config;
            _context = context;
        }

        public async Task Add(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<Employee> Find(int id)
        {
            return await _context.Employees
                 .Where(e => e.Id == id)
                 .SingleOrDefaultAsync();
        }

        public async Task<List<Employee>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task Remove(int id)
        {
            Employee employeeToRemove = await _context.Employees.SingleOrDefaultAsync(e => e.Id == id);
            if (employeeToRemove != null)
            {
                _context.Employees.Remove(employeeToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Update(Employee employee)
        {
            Employee employeeToUpdate = await _context.Employees.SingleOrDefaultAsync(e => e.Id == employee.Id);
            if (employeeToUpdate != null)
            {
                employeeToUpdate.FirstName = employee.FirstName;
                employeeToUpdate.LastName = employee.LastName;
                employeeToUpdate.JobTitle = employee.JobTitle;
                employeeToUpdate.Telephone = employee.Telephone;
                employeeToUpdate.MobileTelephone = employee.MobileTelephone;
                employeeToUpdate.Email = employee.Email;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Employee>> GetFirmEmployees(int id)
        {
            return await _context.Employees
                .Where(e => e.FirmId == id)
                .ToListAsync();
        }
    }
}
