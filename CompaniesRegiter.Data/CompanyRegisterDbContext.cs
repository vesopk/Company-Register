using CompaniesRegiter.Models;
using Microsoft.EntityFrameworkCore;

namespace CompaniesRegiter.Data
{
    public class CompanyRegisterDbContext : DbContext
    {
        public CompanyRegisterDbContext()
        {
            
        }

        public CompanyRegisterDbContext(DbContextOptions<CompanyRegisterDbContext> options)
            : base(options)
        { }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Intern> Interns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.ConnectionString);
            }
        }
    }
}
