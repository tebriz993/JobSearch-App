using JobSearchManagementSystem.Application.Interfaces.Commons;
using JobSearchManagementSystem.Domain.Entities.Jobs;
using JobSearchManagementSystem.Persistance.EntityFrameworks.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Persistance.EntityFrameworks.Repositories
{
    public class EFVacancyDetailRepository : EFGenericRepository<VacancyDetail>, IVacancyDetailRepository
    {
        public EFVacancyDetailRepository(JobSearchDbContext dbContext) : base(dbContext)
        {
        }

        public async Task DeleteAsync(VacancyDetail vacancyDetail)
        {
            Table.Remove(vacancyDetail);
            await SaveChanges();
        }

        public async Task<IEnumerable<VacancyDetail>> GetAllVacancyDetails()
        {
            return await Table
                .Include(x => x.Vacancy)
                .Include(x => x.Company)
                .Include(x => x.JobInformation).ThenInclude(y=>y.JobDetailInformations)
                .Include(x => x.Address)
                .Include(x => x.Categories)
                .Include(x => x.JobTypes)
                .Include(x => x.Specialties)
                .ToListAsync();
        }

        public async Task UpdateAsync(VacancyDetail vacancyDetail)
        {
            Table.Update(vacancyDetail);
            await SaveChanges();
        }

       
    }
}