namespace CompanyRegister.Web.Controllers
{
    using System.Linq;
    using AutoMapper;
    using CompaniesRegister.Services.Implementations;
    using CompaniesRegiter.Models;
    using Models.BindingModels;
    using Models.DTOs;
    using Models.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class CompaniesController : Controller
    {
        private CompanyServices CompanyServices { get;}

        private IMapper Mapper { get; }

        public CompaniesController(CompanyServices services, IMapper mapper)
        {
            this.CompanyServices = services;
            this.Mapper = mapper;
        }

        public IActionResult Index()
        {
            var companies = this.CompanyServices.GetLastThreeCompanies();

            return View(companies);
        }

        public IActionResult All()
        {
            var companies = this.CompanyServices.GetAllCompanies();
            return View(companies);
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterCompanyBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var company = this.Mapper.Map<Company>(model);
            var isTaken = this.CompanyServices.NameIsTaken(company.Name);

            if (isTaken)
            {
                ModelState.AddModelError("Name", "Name is already taken!");
                return this.View();
            }
            this.CompanyServices.AddToDatabase(company);
            return RedirectToAction("Details",new{id=company.Id,slug=company.Name});
        }

        public IActionResult Details(int id,string slug)
        {
            var company = this.CompanyServices.GetCompanyById(id);

            if (company == null || company.Name != slug)
            {
                return NotFound();
            }

            return this.View(company);
        }

        public IActionResult CompanyEmployees(int id, string slug)
        {
            var company = this.CompanyServices.GetCompanyById(id);

            if (company == null || company.Name != slug)
            {
                return NotFound();
            }

            var employees = company.Employees.ToList();
            var vm = new CompanyEmployeesViewModel
            {
                Employees = employees,
                CompanyName = company.Name
            };

            return this.View(vm);
        }

        public IActionResult CompanyInterns(int id, string slug)
        {
            var company = this.CompanyServices.GetCompanyById(id);

            if (company == null || company.Name != slug)
            {
                return NotFound();
            }

            var interns = company.Interns.ToList();
            var vm = new CompanyInternsViewModel()
            {
                CompanyName = company.Name,
                Interns = interns
            };

            return this.View(vm);
        }

        public IActionResult Edit(int id, string slug)
        {
            var company = this.CompanyServices.GetCompanyById(id);

            if (company == null || company.Name != slug)
            {
                return NotFound();
            }

            return this.View(company);
        }

        [HttpPost]
        public IActionResult Edit(EditCompanyBindingModel bm,int id)
        {
            var company = CompanyServices.GetCompanyById(id);

            if (bm.Name != null)
            {
                var isTaken = CompanyServices.NameIsTaken(bm.Name);
                if (isTaken)
                {
                    ModelState.AddModelError("Name","This name is already taken");
                    return this.View(company);
                }

                company.Name = bm.Name;
            }

            if (bm.FoundationDate != null)
            {
                company.FoundationDate = bm.FoundationDate.Value;
            }

            if (bm.PictureUrl != null)
            {
                company.PictureUrl = bm.PictureUrl;
            }

            this.CompanyServices.UpdateCompany(company);
            this.ViewData["edit"] = "You have successfully edited this company!";
            return this.View(company);
        }

        public IActionResult Delete(int id,string slug)
        {
            var company = CompanyServices.GetCompanyById(id);
            if (company == null || company.Name != slug)
            {
                return NotFound();
            }

            return this.View(company);
        }

        public IActionResult FinalDelete(int id, string slug)
        {
            var company = CompanyServices.GetCompanyById(id);
            if (company == null || company.Name != slug)
            {
                return NotFound();
            }

            var dto = new FinalDeleteNameDTO()
            {
                Name = company.Name
            };

            this.CompanyServices.RemoveCompany(company);

            return this.View(dto);
        }
    }
}