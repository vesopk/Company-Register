using CompaniesRegister.Services.Implementations;
using CompaniesRegiter.Data;
using CompaniesRegiter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompaniesRegister.Tests.InMemoryTests
{
    [TestClass]
    public class CompanyServiceTests
    {
        [TestMethod]
        public void ReturnsAll()
        {
            var options = new DbContextOptionsBuilder<CompanyRegisterDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            var companyServices = new CompanyServices(new CompanyRegisterDbContext(options));
            var company = new Company()
            {
                Id = 1,
                Name = "Apple",
                PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fa/Apple_logo_black.svg/160px-Apple_logo_black.svg.png"
            };
            companyServices.AddToDatabase(company);
            var all = companyServices.GetAllCompanies();

            if (all.Count == 0)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void GetsLastThreeCompanies()
        {
            var options = new DbContextOptionsBuilder<CompanyRegisterDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            var companyServices = new CompanyServices(new CompanyRegisterDbContext(options));
            var company = new Company()
            {
                Id = 1,
                Name = "Apple",
                PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fa/Apple_logo_black.svg/160px-Apple_logo_black.svg.png"
            };
            var secondCompany = new Company()
            {
                Id = 2,
                Name = "Nike",
                PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fa/Apple_logo_black.svg/160px-Apple_logo_black.svg.png"
            };
            var thirdCompany = new Company()
            {
                Id = 3,
                Name = "Ozone",
                PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fa/Apple_logo_black.svg/160px-Apple_logo_black.svg.png"
            };
            var forthCompany = new Company()
            {
                Id = 4,
                Name = "Amazon",
                PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fa/Apple_logo_black.svg/160px-Apple_logo_black.svg.png"
            };
            companyServices.AddToDatabase(company);
            companyServices.AddToDatabase(secondCompany);
            companyServices.AddToDatabase(thirdCompany);
            companyServices.AddToDatabase(forthCompany);

            var result = companyServices.GetLastThreeCompanies();

            if (result.Count != 3)
            {
                Assert.Fail();
            }

        }

        [TestMethod]
        public void NameIsTaken()
        {
            var options = new DbContextOptionsBuilder<CompanyRegisterDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            var companyServices = new CompanyServices(new CompanyRegisterDbContext(options));
            var company = new Company()
            {
                Id = 1,
                Name = "Apple",
                PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fa/Apple_logo_black.svg/160px-Apple_logo_black.svg.png"
            };
            companyServices.AddToDatabase(company);

            var nameIsTaken = companyServices.NameIsTaken("Apple");

            if (!nameIsTaken)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void GetCompanyByName()
        {
            var options = new DbContextOptionsBuilder<CompanyRegisterDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            var companyServices = new CompanyServices(new CompanyRegisterDbContext(options));
            var company = new Company()
            {
                Id = 1,
                Name = "Apple",
                PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fa/Apple_logo_black.svg/160px-Apple_logo_black.svg.png"
            };
            companyServices.AddToDatabase(company);
            var result = companyServices.GetCompanyById(1);

            if (result == null || result.Name != "Apple")
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void UpdateCompany()
        {
            var options = new DbContextOptionsBuilder<CompanyRegisterDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            var companyServices = new CompanyServices(new CompanyRegisterDbContext(options));
            var company = new Company()
            {
                Id = 1,
                Name = "Apple",
                PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fa/Apple_logo_black.svg/160px-Apple_logo_black.svg.png"
            };
            companyServices.AddToDatabase(company);
            company.Name = "Nike";
            companyServices.UpdateCompany(company);

            var result = companyServices.GetCompanyById(1);
            if (result.Name != "Nike")
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void RemoveCompany()
        {
            var options = new DbContextOptionsBuilder<CompanyRegisterDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            var companyServices = new CompanyServices(new CompanyRegisterDbContext(options));
            var company = new Company()
            {
                Id = 1,
                Name = "Apple",
                PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fa/Apple_logo_black.svg/160px-Apple_logo_black.svg.png"
            };
            var secondCompany = new Company()
            {
                Id = 2,
                Name = "Nike",
                PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fa/Apple_logo_black.svg/160px-Apple_logo_black.svg.png"
            };
            companyServices.AddToDatabase(company);
            companyServices.AddToDatabase(secondCompany);
            companyServices.RemoveCompany(secondCompany);

            var result = companyServices.GetAllCompanies();

            if (result.Count != 1)
            {
                Assert.Fail();
            }
        }
    }
}
