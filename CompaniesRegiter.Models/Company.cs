using System;
using System.Collections.Generic;

namespace CompaniesRegiter.Models
{
    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime FoundationDate { get; set; }

        public string PictureUrl { get; set; }

        public List<Employee> Employees { get; set; } = new List<Employee>();

        public List<Intern> Interns { get; set; } = new List<Intern>();
    }
}
