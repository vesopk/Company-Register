namespace CompanyRegister.Web.Controllers
{
    using System.Linq;
    using AutoMapper;
    using CompaniesRegister.Services.Implementations;
    using CompaniesRegiter.Models;
    using Models.BindingModels;
    using Models.DTOs;
    using Microsoft.AspNetCore.Mvc;

    public class EmployeesController : Controller
    {
        private EmployeeServices EmployeeServices { get;}

        private CompanyServices CompanyServices { get;}

        private IMapper Mapper { get;}

        public EmployeesController(
            EmployeeServices employeeServices, 
            CompanyServices companyServices,
            IMapper mapper)
        {
            this.EmployeeServices = employeeServices;
            this.CompanyServices = companyServices;
            this.Mapper = mapper;
        }

        public IActionResult Index()
        {
            var employees = EmployeeServices.GetLastThreeEmployees();
            return View(employees);
        }

        public IActionResult All()
        {
            var employees = EmployeeServices.GetAllEmployees();
            return this.View(employees);
        }

        public IActionResult Register()
        {
            var companies = CompanyServices.GetAllCompanies();
            return this.View(companies);
        }

        [HttpPost]
        public IActionResult Register(RegisterEmployeeBindingModel bm)
        {
            var expLevels = new[] {"A","B","C","D"};

            if (!expLevels.Contains(bm.ExperinceLevel))
            {
                ModelState.AddModelError("ExperinceLevel", "Experince Level must be \"A\", \"B\", \"C\", \"D\"");
                var companies = CompanyServices.GetAllCompanies();
                return this.View(companies);
            }

            var employee = this.Mapper.Map<Employee>(bm);
            this.EmployeeServices.AddEmployee(employee);
            return RedirectToAction("Details", new { id = employee.Id, slug = employee.Name });
        }

        public IActionResult Details(int id,string slug)
        {
            var employee = EmployeeServices.GetEmployeeById(id);

            if (employee == null || employee.Name != slug)
            {
                return NotFound();
            }

            return this.View(employee);
        }

        public IActionResult Edit(int id, string slug)
        {
            var employee = EmployeeServices.GetEmployeeById(id);
            var comapnies = CompanyServices.GetAllCompanies();

            if (employee == null || employee.Name != slug)
            {
                return NotFound();
            }

            var employeeDto = new EditEmployeeDto()
            {
                Employee = employee,
                Companies = comapnies
            };

            return this.View(employeeDto);
        }

        [HttpPost]
        public IActionResult Edit(EditEmployeeBindingModel bm,int id)
        {
            var employee = EmployeeServices.GetEmployeeById(id);

            var expLevels = new[] { "A", "B", "C", "D" };

            if (bm.ExperinceLevel != null && !expLevels.Contains(bm.ExperinceLevel))
            {
                ModelState.AddModelError("ExperinceLevel", "Experince Level must be \"A\", \"B\", \"C\", \"D\"");
                var dtoComp = CompanyServices.GetAllCompanies();
                var dto = new EditEmployeeDto()
                {
                    Companies = dtoComp,
                    Employee = employee
                };
                return this.View(dto);
            }

            EditEmployee(bm, employee);

            this.EmployeeServices.UpdateEmployee(employee);
            var companies = this.CompanyServices.GetAllCompanies();
            employee = EmployeeServices.GetEmployeeById(id);

            var employeeDto = new EditEmployeeDto()
            {
                Employee = employee,
                Companies = companies
            };

            this.ViewData["edit"] = "You have successfully edited this employee!";

            return this.View(employeeDto);
        }

        public IActionResult Delete(int id, string slug)
        {
            var employee = EmployeeServices.GetEmployeeById(id);

            if (employee == null || employee.Name != slug)
            {
                return NotFound();
            }

            return this.View(employee);
        }

        public IActionResult FinalDelete(int id, string slug)
        {
            var employee = EmployeeServices.GetEmployeeById(id);
            if (employee == null || employee.Name != slug)
            {
                return NotFound();
            }

            var dto = new FinalDeleteNameDTO()
            {
                Name = employee.Name
            };

            this.EmployeeServices.RemoveEmployee(employee);

            return this.View(dto);
        }

        private static void EditEmployee(EditEmployeeBindingModel bm, Employee employee)
        {
            if (bm.ExperinceLevel != null)
            {
                employee.ExperinceLevel = bm.ExperinceLevel;
            }

            if (bm.Name != null)
            {
                employee.Name = bm.Name;
            }

            if (bm.CompanyId != null)
            {
                employee.CompanyId = bm.CompanyId.Value;
            }

            if (bm.PictureUrl != null)
            {
                employee.PictureUrl = bm.PictureUrl;
            }

            if (bm.Salary != null)
            {
                employee.Salary = bm.Salary.Value;
            }

            if (bm.StartDate != null)
            {
                employee.StartDate = bm.StartDate.Value;
            }

            if (bm.VacationDays != null)
            {
                employee.VacationDays = bm.VacationDays.Value;
            }
        }
    }
}