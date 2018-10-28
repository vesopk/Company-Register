using System.Collections.Generic;
using CompaniesRegiter.Models;

namespace CompaniesRegister.Services.Contracts
{
    public interface IInternServices
    {
        List<Intern> GetLastThreeInterns();

        Intern GetInternById(int id);

        List<Intern> GetAllInterns();

        void AddIntern(Intern intern);

        void RemoveIntern(Intern intern);

        void UpdateIntern(Intern intern);
    }
}
