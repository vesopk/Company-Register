using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompaniesRegiter.Models;

namespace CompanyRegister.Web.Models.ViewModels
{
    public class CompanyEmployeesViewModel
    {
        public string CompanyName { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
