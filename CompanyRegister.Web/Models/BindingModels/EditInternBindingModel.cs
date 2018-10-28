using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyRegister.Web.Models.BindingModels
{
    public class EditInternBindingModel
    {
        public string Name { get; set; }

        public DateTime? StartDate { get; set; }

        public int? CompanyId { get; set; }

        public double? Salary { get; set; }

        public int? DaysOfInternship { get; set; }

        public string PictureUrl { get; set; }
    }
}
