using System;

namespace CompanyRegister.Web.Models.BindingModels
{
    public class EditCompanyBindingModel
    {
        public string Name { get; set; }

        public DateTime? FoundationDate { get; set; }

        public string PictureUrl { get; set; }
    }
}
