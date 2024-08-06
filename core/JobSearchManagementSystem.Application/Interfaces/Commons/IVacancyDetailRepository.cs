using JobSearchManagementSystem.Domain.Entities.Jobs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Application.Interfaces.Commons
{
    public interface IVacancyDetailRepository : IRepository<VacancyDetail>
    {
        Task<IEnumerable<VacancyDetail>> GetAllVacancyDetails();
        Task UpdateAsync(VacancyDetail vacancyDetail);
        Task DeleteAsync(VacancyDetail vacancyDetail);
        Task<VacancyDetail> GetByIdAsync(int id);
    }
}
