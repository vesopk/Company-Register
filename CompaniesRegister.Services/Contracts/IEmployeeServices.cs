using System.Collections.Generic;
using CompaniesRegiter.Models;

namespace CompaniesRegister.Services.Contracts
{
    public interface IEmployeeServices
    {
        List<Employee> GetLastThreeEmployees();

        List<Employee> GetAllEmployees();

        void AddEmployee(Employee employee);

        Employee GetEmployeeById(int id);

        void UpdateEmployee(Employee employee);

        void RemoveEmployee(Employee employee);
    }
}
