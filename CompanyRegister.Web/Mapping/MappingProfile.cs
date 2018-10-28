using AutoMapper;
using CompaniesRegiter.Models;
using CompanyRegister.Web.Models.BindingModels;

namespace CompanyRegister.Web.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterCompanyBindingModel, Company>();
            CreateMap<RegisterEmployeeBindingModel, Employee>();
            CreateMap<RegisterInternBindingModel, Intern>();
        }
    }
}
