using System;

namespace CompanyRegister.Web.Models.BindingModels
{
    public class RegisterInternBindingModel
    {
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public int CompanyId { get; set; }

        public double Salary { get; set; }

        public int DaysOfInternship { get; set; }

        public string PictureUrl { get; set; }
    }
}
