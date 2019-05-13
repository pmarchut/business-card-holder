using BusinessCardHolder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessCardHolder.Repository
{
    public interface IEmployeeRepository
    {
        Task Add(Employee employee);
        Task<Employee> Find(int id);
        Task<List<Employee>> GetAll();
        Task Remove(int id);
        Task Update(Employee firm);
        Task<List<Employee>> GetFirmEmployees(int id);
    }
}
