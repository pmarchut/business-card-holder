using BusinessCardHolder.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BusinessCardHolder.Contexts
{
    public class BusinessCardHolderContext : DbContext
    {
        public IConfiguration _config;

        public DbSet<Firm> Firms { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public BusinessCardHolderContext(IConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config["database:connection"]);
        }
    }
}
