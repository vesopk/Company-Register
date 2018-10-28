using System.Collections.Generic;
using System.Linq;
using CompaniesRegister.Services.Contracts;
using CompaniesRegiter.Data;
using CompaniesRegiter.Models;
using Microsoft.EntityFrameworkCore;

namespace CompaniesRegister.Services.Implementations
{
    public class InternServices : IInternServices
    {
        private CompanyRegisterDbContext Database { get;}

        public InternServices()
        {
            this.Database = new CompanyRegisterDbContext();
        }

        public InternServices(CompanyRegisterDbContext db)
        {
            this.Database = db;
        }

        public List<Intern> GetLastThreeInterns()
        {
            var interns = Database.Interns.Include(i => i.Company).ToList();
            interns.Reverse();

            return interns.Take(3).ToList();
        }

        public Intern GetInternById(int id)
        {
            var intern = this.Database.Interns.Include(i => i.Company).FirstOrDefault(i => i.Id == id);
            return intern;
        }

        public List<Intern> GetAllInterns()
        {
            var interns = this.Database.Interns.Include(i => i.Company).ToList();
            return interns;
        }

        public void AddIntern(Intern intern)
        {
            this.Database.Interns.Add(intern);
            this.Database.SaveChanges();
        }

        public void RemoveIntern(Intern intern)
        {
            this.Database.Interns.Remove(intern);
            this.Database.SaveChanges();
        }

        public void UpdateIntern(Intern intern)
        {
            this.Database.Interns.Update(intern);
            this.Database.SaveChanges();
        }
    }
}
