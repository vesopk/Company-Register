using System.Collections.Generic;
using CompaniesRegiter.Models;

namespace CompanyRegister.Web.Models.ViewModels
{
    public class CompanyInternsViewModel
    {
        public string CompanyName { get; set; }

        public List<Intern> Interns { get; set; }
    }
}
