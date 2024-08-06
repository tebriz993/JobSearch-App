using JobSearchManagementSystem.Application.Interfaces.Commons;
using JobSearchManagementSystem.Domain.Entities.Jobs;
using JobSearchManagementSystem.Persistance.EntityFrameworks.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Persistance.EntityFrameworks.Repositories
{
    public class EFVacanciesRepository : EFGenericRepository<Vacancy>, IVacanciesRepository
    {
        public EFVacanciesRepository(JobSearchDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<Vacancy> GetByIdAsync(int id)
        {
            return await Table
                .Include(x => x.Company)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
