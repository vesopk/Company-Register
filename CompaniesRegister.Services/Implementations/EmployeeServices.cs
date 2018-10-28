using System.Collections.Generic;
using System.Linq;
using CompaniesRegister.Services.Contracts;
using CompaniesRegiter.Data;
using CompaniesRegiter.Models;
using Microsoft.EntityFrameworkCore;

namespace CompaniesRegister.Services.Implementations
{
    public class EmployeeServices : IEmployeeServices
    {
        private CompanyRegisterDbContext Database { get;}

        public EmployeeServices()
        {
            this.Database = new CompanyRegisterDbContext();
        }

        public EmployeeServices(CompanyRegisterDbContext db)
        {
            this.Database = db;
        }

        public List<Employee> GetLastThreeEmployees()
        {
            var employees = Database.Employees.Include(e => e.Company).ToList();
            employees.Reverse();

            return employees.Take(3).ToList();
        }

        public List<Employee> GetAllEmployees()
        {
            var employees = Database.Employees.Include(e => e.Company).ToList();
            return employees;
        }

        public void AddEmployee(Employee employee)
        {
            this.Database.Employees.Add(employee);
            this.Database.SaveChanges();
        }

        public Employee GetEmployeeById(int id)
        {
            var employee = this.Database.Employees.Include(e => e.Company).FirstOrDefault(e => e.Id == id);
            return employee;
        }

        public void UpdateEmployee(Employee employee)
        {
            this.Database.Employees.Update(employee);
            this.Database.SaveChanges();
        }

        public void RemoveEmployee(Employee employee)
        {
            this.Database.Employees.Remove(employee);
            this.Database.SaveChanges();
        }
    }
}
