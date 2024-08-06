using JobSearchManagementSystem.Application.Interfaces.Account;
using JobSearchManagementSystem.Domain.Entities.Account;
using JobSearchManagementSystem.Persistance.EntityFrameworks.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Persistance.EntityFrameworks.Repositories
{
    public class EFUserRepository:IUserRepository
    {
        private readonly JobSearchDbContext _dbContext;
        public EFUserRepository(JobSearchDbContext dbContext)
        {
            _dbContext= dbContext;
        }

        public async Task AddUser(User user)
        {
            await _dbContext.Set<User>().AddAsync(user);
        }

        public async Task<User?> GetUserWithDetail(string email)
        {
            return await _dbContext.Set<User>()
                 .Include(x => x.UserDetail)
                 .FirstOrDefaultAsync(x => x.Email == email);
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
