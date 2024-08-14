using JobSearchManagementSystem.Application.Interfaces.Commons;
using JobSearchManagementSystem.Domain.Entities.Jobs;
using JobSearchManagementSystem.Persistance.EntityFrameworks.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Persistance.EntityFrameworks.Repositories
{
    public class EFCompaniesRepository : EFGenericRepository<Companies>, ICompaniesRepository
    {
        public EFCompaniesRepository(JobSearchDbContext dbContext) : base(dbContext)
        {
        }

        
    }
}
