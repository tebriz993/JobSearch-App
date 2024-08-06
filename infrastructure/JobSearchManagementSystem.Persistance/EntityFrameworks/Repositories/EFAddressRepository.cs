using JobSearchManagementSystem.Application.Interfaces.Commons;
using JobSearchManagementSystem.Domain.Entities.Jobs;
using JobSearchManagementSystem.Persistance.EntityFrameworks.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Persistance.EntityFrameworks.Repositories
{
    public class EFAddressRepository : EFGenericRepository<Address>, IAddressRepository
    {
        public EFAddressRepository(JobSearchDbContext dbContext) : base(dbContext)
        {
        }

        
        
    }
}
