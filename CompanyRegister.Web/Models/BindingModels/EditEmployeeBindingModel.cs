﻿using System;

namespace CompanyRegister.Web.Models.BindingModels
{
    public class EditEmployeeBindingModel
    {
        public string Name { get; set; }

        public DateTime? StartDate { get; set; }

        public int? CompanyId { get; set; }

        public string ExperinceLevel { get; set; }

        public double? Salary { get; set; }

        public int? VacationDays { get; set; }

        public string PictureUrl { get; set; }
    }
}
