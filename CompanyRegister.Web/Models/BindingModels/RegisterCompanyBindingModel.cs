using System;
using System.ComponentModel.DataAnnotations;

namespace CompanyRegister.Web.Models.BindingModels
{
    public class RegisterCompanyBindingModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Foundation Date is required")]
        [Display(Name = "Foundation Date")]
        public DateTime FoundationDate { get; set; }

        [Required(ErrorMessage = "Picture Url is required")]
        [DataType(DataType.ImageUrl)]
        public string PictureUrl { get; set; }
    }
}
