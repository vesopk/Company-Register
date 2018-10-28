using System.Collections.Generic;
using CompaniesRegiter.Models;

namespace CompaniesRegister.Services.Contracts
{
    public interface ICompanyServices
    {
        List<Company> GetLastThreeCompanies();

        List<Company> GetAllCompanies();

        bool NameIsTaken(string name);

        void AddToDatabase(Company company);

        Company GetCompanyById(int id);

        void UpdateCompany(Company company);

        void RemoveCompany(Company company);
    }
}
