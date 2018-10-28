using System.Collections.Generic;
using CompaniesRegiter.Models;

namespace CompanyRegister.Web.Models.DTOs
{
    public class EditInternDto
    {
        public Intern Intern { get; set; }

        public List<Company> Companies { get; set; }
    }
}
