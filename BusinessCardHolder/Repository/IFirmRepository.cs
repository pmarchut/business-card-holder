using BusinessCardHolder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessCardHolder.Repository
{
    public interface IFirmRepository
    {
        Task Add(Firm firm);
        Task<Firm> Find(int id);
        Task<List<Firm>> GetAll();
        Task Remove(int id);
        Task Update(Firm firm);
    }
}
