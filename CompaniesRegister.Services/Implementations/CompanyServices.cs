using System.Collections.Generic;
using System.Linq;
using CompaniesRegister.Services.Contracts;
using CompaniesRegiter.Data;
using CompaniesRegiter.Models;
using Microsoft.EntityFrameworkCore;

namespace CompaniesRegister.Services.Implementations
{
    public class CompanyServices : ICompanyServices
    {
        private CompanyRegisterDbContext Database { get;}

        public CompanyServices()
        {
            this.Database = new CompanyRegisterDbContext();
        }

        public CompanyServices(CompanyRegisterDbContext db)
        {
            this.Database = db;
        }
        public List<Company> GetLastThreeCompanies()
        {
            var companies = Database.Companies.Include(c => c.Employees).Include(c => c.Interns).ToList();
            companies.Reverse();

            return companies.Take(3).ToList();
        }

        public List<Company> GetAllCompanies()
        {
            var companies = Database.Companies.Include(c => c.Employees).Include(c => c.Interns).ToList();
            return companies;
        }

        public bool NameIsTaken(string name)
        {
            var company = Database.Companies.FirstOrDefault(c => c.Name == name);

            if (company != null)
            {
                return true;
            }

            return false;
        }

        public void AddToDatabase(Company company)
        {
            this.Database.Companies.Add(company);
            this.Database.SaveChanges();
        }

        public Company GetCompanyById(int id)
        {
            return Database.Companies.Include(c => c.Employees).Include(c => c.Interns).FirstOrDefault(c => c.Id == id);
        }

        public void UpdateCompany(Company company)
        {
            this.Database.Companies.Update(company);
            this.Database.SaveChanges();
        }

        public void RemoveCompany(Company company)
        {
            this.Database.Companies.Remove(company);
            this.Database.SaveChanges();
        }
    }
}
