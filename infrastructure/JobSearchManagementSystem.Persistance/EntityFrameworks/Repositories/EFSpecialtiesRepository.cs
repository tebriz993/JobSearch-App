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
    public class EFSpecialtiesRepository : EFGenericRepository<Specialties>, ISpecialtiesRepository
    {
        public EFSpecialtiesRepository(JobSearchDbContext dbContext) : base(dbContext)
        {
        }



    }
}
