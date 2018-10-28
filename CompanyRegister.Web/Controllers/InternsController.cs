using AutoMapper;
using CompaniesRegister.Services.Implementations;
using CompaniesRegiter.Models;
using CompanyRegister.Web.Models.BindingModels;
using CompanyRegister.Web.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CompanyRegister.Web.Controllers
{
    public class InternsController : Controller
    {
        private InternServices InternServices { get;}

        private CompanyServices CompanyServices { get; }

        private IMapper Mapper { get; }

        public InternsController(
            InternServices internServices,
            CompanyServices companyServices,
            IMapper mapper)
        {
            this.InternServices = internServices;
            this.CompanyServices = companyServices;
            this.Mapper = mapper;
        }

        public IActionResult Index()
        {
            var interns = InternServices.GetLastThreeInterns();
            return View(interns);
        }

        public IActionResult Details(int id,string slug)
        {
            var intern = InternServices.GetInternById(id);

            if (intern == null || intern.Name != slug)
            {
                return NotFound();
            }

            return this.View(intern);
        }

        public IActionResult All()
        {
            var interns = InternServices.GetAllInterns();
            return this.View(interns);
        }

        public IActionResult Register()
        {
            var companies = this.CompanyServices.GetAllCompanies();
            return this.View(companies);
        }

        [HttpPost]
        public IActionResult Register(RegisterInternBindingModel bm)
        {
            if (!ModelState.IsValid)
            {
                var companies = this.CompanyServices.GetAllCompanies();
                return this.View(companies);
            }

            var intern = this.Mapper.Map<Intern>(bm);
            this.InternServices.AddIntern(intern);

            return this.RedirectToAction("Details",new{id=intern.Id,slug=intern.Name});
        }

        public IActionResult Delete(int id, string slug)
        {
            var intern = InternServices.GetInternById(id);

            if (intern == null || intern.Name != slug)
            {
                return NotFound();
            }

            return this.View(intern);
        }

        public IActionResult FinalDelete(int id, string slug)
        {
            var intern = InternServices.GetInternById(id);
            if (intern == null || intern.Name != slug)
            {
                return NotFound();
            }

            var dto = new FinalDeleteNameDTO()
            {
                Name = intern.Name
            };

            this.InternServices.RemoveIntern(intern);

            return this.View(dto);
        }

        public IActionResult Edit(int id,string slug)
        {
            var intern = InternServices.GetInternById(id);
            var comapnies = CompanyServices.GetAllCompanies();

            if (intern == null || intern.Name != slug)
            {
                return NotFound();
            }

            var internDto = new EditInternDto()
            {
                Intern = intern,
                Companies = comapnies
            };

            return this.View(internDto);
        }

        [HttpPost]
        public IActionResult Edit(EditInternBindingModel bm, int id)
        {
            var intern = InternServices.GetInternById(id);

            if (!ModelState.IsValid)
            {
                var comapnies = CompanyServices.GetAllCompanies();

                var internDto = new EditInternDto()
                {
                    Intern = intern,
                    Companies = comapnies
                };

                return this.View(internDto);
            }

            EditIntern(bm, intern);

            this.InternServices.UpdateIntern(intern);
            var companies = this.CompanyServices.GetAllCompanies();
            intern = InternServices.GetInternById(id);

            var dto = new EditInternDto()
            {
                Intern = intern,
                Companies = companies
            };
            this.ViewData["edit"] = "You have successfully edited this intern!";

            return this.View(dto);
        }

        private static void EditIntern(EditInternBindingModel bm, Intern intern)
        {
            if (bm.Name != null)
            {
                intern.Name = bm.Name;
            }
            if (bm.CompanyId != null)
            {
                intern.CompanyId = bm.CompanyId.Value;
            }

            if (bm.PictureUrl != null)
            {
                intern.PictureUrl = bm.PictureUrl;
            }

            if (bm.Salary != null)
            {
                intern.Salary = bm.Salary.Value;
            }

            if (bm.StartDate != null)
            {
                intern.StartDate = bm.StartDate.Value;
            }

            if (bm.DaysOfInternship != null)
            {
                intern.DaysOfInternship = bm.DaysOfInternship.Value;
            }
        }
    }
}