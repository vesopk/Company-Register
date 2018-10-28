using System;
using CompaniesRegister.Services.Implementations;
using CompaniesRegiter.Data;
using CompaniesRegiter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompaniesRegister.Tests.InMemoryTests
{
    [TestClass]
    public class EmployeesServiceTests
    {
        [TestMethod]
        public void GetAllEmployees()
        {
            var options = new DbContextOptionsBuilder<CompanyRegisterDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            var employeeService = new EmployeeServices(new CompanyRegisterDbContext(options));
            var companyServices = new CompanyServices(new CompanyRegisterDbContext(options));

            var company = new Company()
            {
                Id = 1,
                Name = "Apple",
                PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fa/Apple_logo_black.svg/160px-Apple_logo_black.svg.png"
            };
            companyServices.AddToDatabase(company);

            var employee = new Employee()
            {
                Id = 1,
                CompanyId = 1,
                ExperinceLevel = "A",
                Name = "Veselin",
                PictureUrl =
                    "https://images-eu.ssl-images-amazon.com/images/G/31/img16/imports/AGS/MensFashion_Cat_Clothing._V279132526_.jpg",
                Salary = 1400,
                VacationDays = 15,
                StartDate = DateTime.Now
            };

            employeeService.AddEmployee(employee);
            var tempEmployee = employeeService.GetAllEmployees();

            if (tempEmployee.Count != 1)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void GetLastThreeEmployees()
        {
            var options = new DbContextOptionsBuilder<CompanyRegisterDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            var employeeService = new EmployeeServices(new CompanyRegisterDbContext(options));
            var companyServices = new CompanyServices(new CompanyRegisterDbContext(options));

            var company = new Company()
            {
                Id = 1,
                Name = "Apple",
                PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fa/Apple_logo_black.svg/160px-Apple_logo_black.svg.png"
            };
            companyServices.AddToDatabase(company);

            var employee = new Employee()
            {
                Id = 1,
                CompanyId = 1,
                ExperinceLevel = "A",
                Name = "Veselin",
                PictureUrl =
                    "https://images-eu.ssl-images-amazon.com/images/G/31/img16/imports/AGS/MensFashion_Cat_Clothing._V279132526_.jpg",
                Salary = 1400,
                VacationDays = 15,
                StartDate = DateTime.Now
            };
            var secondEmployee = new Employee()
            {
                Id = 2,
                CompanyId = 1,
                ExperinceLevel = "A",
                Name = "Karina",
                PictureUrl =
                    "https://images-eu.ssl-images-amazon.com/images/G/31/img16/imports/AGS/MensFashion_Cat_Clothing._V279132526_.jpg",
                Salary = 1400,
                VacationDays = 15,
                StartDate = DateTime.Now
            };
            var thirdEmployee = new Employee()
            {
                Id = 3,
                CompanyId = 1,
                ExperinceLevel = "A",
                Name = "Ivelin",
                PictureUrl =
                    "https://images-eu.ssl-images-amazon.com/images/G/31/img16/imports/AGS/MensFashion_Cat_Clothing._V279132526_.jpg",
                Salary = 1400,
                VacationDays = 15,
                StartDate = DateTime.Now
            };

            var fourthEmployee = new Employee()
            {
                Id = 4,
                CompanyId = 1,
                ExperinceLevel = "A",
                Name = "Pesho",
                PictureUrl =
                    "https://images-eu.ssl-images-amazon.com/images/G/31/img16/imports/AGS/MensFashion_Cat_Clothing._V279132526_.jpg",
                Salary = 1400,
                VacationDays = 15,
                StartDate = DateTime.Now
            };

            employeeService.AddEmployee(employee);
            employeeService.AddEmployee(secondEmployee);
            employeeService.AddEmployee(thirdEmployee);
            employeeService.AddEmployee(fourthEmployee);

            var result = employeeService.GetLastThreeEmployees();

            if (result.Count != 3)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void GetEmployeeById()
        {
            var options = new DbContextOptionsBuilder<CompanyRegisterDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            var employeeService = new EmployeeServices(new CompanyRegisterDbContext(options));
            var companyServices = new CompanyServices(new CompanyRegisterDbContext(options));

            var company = new Company()
            {
                Id = 1,
                Name = "Apple",
                PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fa/Apple_logo_black.svg/160px-Apple_logo_black.svg.png"
            };
            companyServices.AddToDatabase(company);

            var employee = new Employee()
            {
                Id = 1,
                CompanyId = 1,
                ExperinceLevel = "A",
                Name = "Veselin",
                PictureUrl =
                    "https://images-eu.ssl-images-amazon.com/images/G/31/img16/imports/AGS/MensFashion_Cat_Clothing._V279132526_.jpg",
                Salary = 1400,
                VacationDays = 15,
                StartDate = DateTime.Now
            };

            employeeService.AddEmployee(employee);

            var tempEmployee = employeeService.GetEmployeeById(1);

            if (tempEmployee == null || tempEmployee.Name != "Veselin")
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void UpdateEmployee()
        {
            var options = new DbContextOptionsBuilder<CompanyRegisterDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            var employeeService = new EmployeeServices(new CompanyRegisterDbContext(options));
            var companyServices = new CompanyServices(new CompanyRegisterDbContext(options));

            var company = new Company()
            {
                Id = 1,
                Name = "Apple",
                PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fa/Apple_logo_black.svg/160px-Apple_logo_black.svg.png"
            };
            companyServices.AddToDatabase(company);

            var employee = new Employee()
            {
                Id = 1,
                CompanyId = 1,
                ExperinceLevel = "A",
                Name = "Veselin",
                PictureUrl =
                    "https://images-eu.ssl-images-amazon.com/images/G/31/img16/imports/AGS/MensFashion_Cat_Clothing._V279132526_.jpg",
                Salary = 1400,
                VacationDays = 15,
                StartDate = DateTime.Now
            };

            employeeService.AddEmployee(employee);
            employee.ExperinceLevel = "B";
            employeeService.UpdateEmployee(employee);

            var tempEmployee = employeeService.GetEmployeeById(1);

            if (tempEmployee.ExperinceLevel != "B")
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void RemoveEmployee()
        {
            var options = new DbContextOptionsBuilder<CompanyRegisterDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            var employeeService = new EmployeeServices(new CompanyRegisterDbContext(options));
            var companyServices = new CompanyServices(new CompanyRegisterDbContext(options));

            var company = new Company()
            {
                Id = 1,
                Name = "Apple",
                PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fa/Apple_logo_black.svg/160px-Apple_logo_black.svg.png"
            };
            companyServices.AddToDatabase(company);

            var employee = new Employee()
            {
                Id = 1,
                CompanyId = 1,
                ExperinceLevel = "A",
                Name = "Veselin",
                PictureUrl =
                    "https://images-eu.ssl-images-amazon.com/images/G/31/img16/imports/AGS/MensFashion_Cat_Clothing._V279132526_.jpg",
                Salary = 1400,
                VacationDays = 15,
                StartDate = DateTime.Now
            };

            var secondEmployee = new Employee()
            {
                Id = 2,
                CompanyId = 1,
                ExperinceLevel = "A",
                Name = "Pesho",
                PictureUrl =
                    "https://images-eu.ssl-images-amazon.com/images/G/31/img16/imports/AGS/MensFashion_Cat_Clothing._V279132526_.jpg",
                Salary = 1400,
                VacationDays = 15,
                StartDate = DateTime.Now
            };

            employeeService.AddEmployee(employee);
            employeeService.AddEmployee(secondEmployee);
            employeeService.RemoveEmployee(employee);

            var result = employeeService.GetAllEmployees();

            if (result.Count != 1)
            {
                Assert.Fail();
            }
        }
    }
}
