using JobSearchManagementSystem.Application.Interfaces.Commons;
using JobSearchManagementSystem.Domain.Entities.Jobs;
using JobSearchManagementSystem.Domain.Entities;
using JobSearchManagementSystem.Persistance.EntityFrameworks.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Persistance.EntityFrameworks.Repositories
{
    public class EFVacanciesRepository : EFGenericRepository<Vacancy>, IVacanciesRepository
    {
        public EFVacanciesRepository(JobSearchDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Vacancy>> GetAllVacancies()
        {
            return await Table
                .Include(x => x.Company)
                .ToListAsync();
        }

        public async Task<Dictionary<int, string>> GetCompanyNamesByIds(IEnumerable<int> companyIds)
        {
            return await Table
                .Include(x => x.Company)
                .ToDictionaryAsync(c => c.Company.Id, c => c.Name);


        }
    }
}
