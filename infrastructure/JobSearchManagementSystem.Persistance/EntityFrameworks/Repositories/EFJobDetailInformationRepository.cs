using JobSearchManagementSystem.Application.Interfaces.Commons;
using JobSearchManagementSystem.Domain.Entities.Jobs;
using JobSearchManagementSystem.Persistance.EntityFrameworks.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Persistance.EntityFrameworks.Repositories
{
    public class EFJobDetailInformationRepository : EFGenericRepository<JobDetailnformation>, IJobDetailInformationRepository
    {
        public EFJobDetailInformationRepository(JobSearchDbContext dbContext) : base(dbContext)
        {
        }
    }
}
