using System;
using CompaniesRegister.Services.Implementations;
using CompaniesRegiter.Data;
using CompaniesRegiter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompaniesRegister.Tests.InMemoryTests
{
    [TestClass]
    public class InternsServiceTests
    {
        [TestMethod]
        public void GetAllInterns()
        {
            var options = new DbContextOptionsBuilder<CompanyRegisterDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            var internService = new InternServices(new CompanyRegisterDbContext(options));
            var companyServices = new CompanyServices(new CompanyRegisterDbContext(options));

            var company = new Company()
            {
                Id = 1,
                Name = "Apple",
                PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fa/Apple_logo_black.svg/160px-Apple_logo_black.svg.png"
            };
            companyServices.AddToDatabase(company);

            var intern = new Intern()
            {
                Id = 1,
                CompanyId = 1,
                Name = "Veselin",
                PictureUrl =
                    "https://images-eu.ssl-images-amazon.com/images/G/31/img16/imports/AGS/MensFashion_Cat_Clothing._V279132526_.jpg",
                Salary = 1400,
                DaysOfInternship = 15,
                StartDate = DateTime.Now
            };

            internService.AddIntern(intern);
            var tempIntern = internService.GetAllInterns();

            if (tempIntern.Count != 1)
            {
                Assert.Fail();
            }
        }


        [TestMethod]
        public void GetLastThreeInterns()
        {
            var options = new DbContextOptionsBuilder<CompanyRegisterDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            var internServices = new InternServices(new CompanyRegisterDbContext(options));
            var companyServices = new CompanyServices(new CompanyRegisterDbContext(options));

            var company = new Company()
            {
                Id = 1,
                Name = "Apple",
                PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fa/Apple_logo_black.svg/160px-Apple_logo_black.svg.png"
            };
            companyServices.AddToDatabase(company);

            var intern = new Intern()
            {
                Id = 1,
                CompanyId = 1,
                Name = "Veselin",
                PictureUrl =
                    "https://images-eu.ssl-images-amazon.com/images/G/31/img16/imports/AGS/MensFashion_Cat_Clothing._V279132526_.jpg",
                Salary = 1400,
                DaysOfInternship = 15,
                StartDate = DateTime.Now
            };
            var secondIntern = new Intern()
            {
                Id = 2,
                CompanyId = 1,
                Name = "Karina",
                PictureUrl =
                    "https://images-eu.ssl-images-amazon.com/images/G/31/img16/imports/AGS/MensFashion_Cat_Clothing._V279132526_.jpg",
                Salary = 1400,
                DaysOfInternship = 15,
                StartDate = DateTime.Now
            };
            var thirdIntern = new Intern()
            {
                Id = 3,
                CompanyId = 1,
                Name = "Ivelin",
                PictureUrl =
                    "https://images-eu.ssl-images-amazon.com/images/G/31/img16/imports/AGS/MensFashion_Cat_Clothing._V279132526_.jpg",
                Salary = 1400,
                DaysOfInternship = 15,
                StartDate = DateTime.Now
            };

            var fourthIntern = new Intern()
            {
                Id = 4,
                CompanyId = 1,
                Name = "Pesho",
                PictureUrl =
                    "https://images-eu.ssl-images-amazon.com/images/G/31/img16/imports/AGS/MensFashion_Cat_Clothing._V279132526_.jpg",
                Salary = 1400,
                DaysOfInternship = 15,
                StartDate = DateTime.Now
            };

            internServices.AddIntern(intern);
            internServices.AddIntern(secondIntern);
            internServices.AddIntern(thirdIntern);
            internServices.AddIntern(fourthIntern);

            var result = internServices.GetLastThreeInterns();

            if (result.Count != 3)
            {
                Assert.Fail();
            }
        }


        [TestMethod]
        public void GetInternById()
        {
            var options = new DbContextOptionsBuilder<CompanyRegisterDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            var internServices = new InternServices(new CompanyRegisterDbContext(options));
            var companyServices = new CompanyServices(new CompanyRegisterDbContext(options));

            var company = new Company()
            {
                Id = 1,
                Name = "Apple",
                PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fa/Apple_logo_black.svg/160px-Apple_logo_black.svg.png"
            };
            companyServices.AddToDatabase(company);

            var intern = new Intern()
            {
                Id = 1,
                CompanyId = 1,
                Name = "Veselin",
                PictureUrl =
                    "https://images-eu.ssl-images-amazon.com/images/G/31/img16/imports/AGS/MensFashion_Cat_Clothing._V279132526_.jpg",
                Salary = 1400,
                DaysOfInternship = 15,
                StartDate = DateTime.Now
            };

            internServices.AddIntern(intern);

            var tempIntern = internServices.GetInternById(1);

            if (tempIntern == null || tempIntern.Name != "Veselin")
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void UpdateIntern()
        {
            var options = new DbContextOptionsBuilder<CompanyRegisterDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            var internServices = new InternServices(new CompanyRegisterDbContext(options));
            var companyServices = new CompanyServices(new CompanyRegisterDbContext(options));

            var company = new Company()
            {
                Id = 1,
                Name = "Apple",
                PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fa/Apple_logo_black.svg/160px-Apple_logo_black.svg.png"
            };
            companyServices.AddToDatabase(company);

            var intern = new Intern()
            {
                Id = 1,
                CompanyId = 1,
                Name = "Veselin",
                PictureUrl =
                    "https://images-eu.ssl-images-amazon.com/images/G/31/img16/imports/AGS/MensFashion_Cat_Clothing._V279132526_.jpg",
                Salary = 1400,
                DaysOfInternship = 15,
                StartDate = DateTime.Now
            };

            internServices.AddIntern(intern);
            intern.DaysOfInternship = 25;
            internServices.UpdateIntern(intern);

            var tempEmployee = internServices.GetInternById(1);

            if (tempEmployee.DaysOfInternship != 25)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void RemoveIntern()
        {
            var options = new DbContextOptionsBuilder<CompanyRegisterDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            var internServices = new InternServices(new CompanyRegisterDbContext(options));
            var companyServices = new CompanyServices(new CompanyRegisterDbContext(options));

            var company = new Company()
            {
                Id = 1,
                Name = "Apple",
                PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fa/Apple_logo_black.svg/160px-Apple_logo_black.svg.png"
            };
            companyServices.AddToDatabase(company);

            var intern = new Intern()
            {
                Id = 1,
                CompanyId = 1,
                Name = "Veselin",
                PictureUrl =
                    "https://images-eu.ssl-images-amazon.com/images/G/31/img16/imports/AGS/MensFashion_Cat_Clothing._V279132526_.jpg",
                Salary = 1400,
                DaysOfInternship = 15,
                StartDate = DateTime.Now
            };

            var secondIntern = new Intern()
            {
                Id = 2,
                CompanyId = 1,
                Name = "Pesho",
                PictureUrl =
                    "https://images-eu.ssl-images-amazon.com/images/G/31/img16/imports/AGS/MensFashion_Cat_Clothing._V279132526_.jpg",
                Salary = 1400,
                DaysOfInternship = 15,
                StartDate = DateTime.Now
            };

            internServices.AddIntern(intern);
            internServices.AddIntern(secondIntern);
            internServices.RemoveIntern(intern);

            var result = internServices.GetAllInterns();

            if (result.Count != 1)
            {
                Assert.Fail();
            }
        }
    }
}
