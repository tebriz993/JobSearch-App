using JobSearchManagementSystem.Domain.Entities.Jobs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Application.Interfaces.Commons
{
    public interface IVacanciesRepository : IRepository<Vacancy>
    {
        Task<IEnumerable<Vacancy>> GetAllVacancies();
        Task<Dictionary<int, string>> GetCompanyNamesByIds(IEnumerable<int> companyIds);
    }
}
