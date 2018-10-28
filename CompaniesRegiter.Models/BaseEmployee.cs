using System;

namespace CompaniesRegiter.Models
{
   public abstract class BaseEmployee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public double Salary { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }

        public string PictureUrl { get; set; }
    }
}
