using System.Collections.Generic;
using CompaniesRegiter.Models;

namespace CompanyRegister.Web.Models.DTOs
{
    public class EditEmployeeDto
    {
        public Employee Employee { get; set; }

        public List<Company> Companies { get; set; }
    }
}
