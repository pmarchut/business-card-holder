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
    public class FirmRepository : IFirmRepository
    {
        public IConfiguration _config;

        BusinessCardHolderContext _context;

        public FirmRepository(IConfiguration config, BusinessCardHolderContext context)
        {
            _config = config;
            _context = context;
        }

        public async Task Add(Firm firm)
        {
            await _context.Firms.AddAsync(firm);
            await _context.SaveChangesAsync();
        }

        public async Task<Firm> Find(int id)
        {
            return await _context.Firms
                 .Where(f => f.Id == id)
                 .SingleOrDefaultAsync();
        }

        public async Task<List<Firm>> GetAll()
        {
            return await _context.Firms.ToListAsync();
        }

        public async Task Remove(int id)
        {
            Firm firmToRemove = await _context.Firms.SingleOrDefaultAsync(f => f.Id == id);
            if(firmToRemove != null)
            {
                _context.Firms.Remove(firmToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Update(Firm firm)
        {
            Firm firmToUpdate = await _context.Firms.SingleOrDefaultAsync(f => f.Id == firm.Id);
            if(firmToUpdate != null)
            {
                firmToUpdate.Name = firm.Name;
                firmToUpdate.NIP = firm.NIP;
                firmToUpdate.Address = firm.Address;
                firmToUpdate.City = firm.City;
                firmToUpdate.PostalCode = firm.PostalCode;
                firmToUpdate.Telephone = firm.Telephone;
                firmToUpdate.Email = firm.Email;
                firmToUpdate.Notes = firm.Notes;
                await _context.SaveChangesAsync();
            }
        }
    }
}
