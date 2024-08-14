using JobSearchManagementSystem.Application.Interfaces.Commons;
using JobSearchManagementSystem.Domain.Entities.Account;
using JobSearchManagementSystem.Persistance.EntityFrameworks.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Persistance.EntityFrameworks.Repositories
{
    public class EFRoleRepository : IRoleRepository
    {
        private readonly JobSearchDbContext _dbContext;

        public EFRoleRepository(JobSearchDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Role role)
        {
            await _dbContext.Role.AddAsync(role);
        }

        public async Task UpdateAsync(Role role)
        {
            _dbContext.Role.Update(role);
        }

        public async Task DeleteAsync(Role role)
        {
            _dbContext.Role.Remove(role);
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await  _dbContext.Role.ToListAsync();
            
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            return await _dbContext.Role.FindAsync(id);
        }
        public async Task<IEnumerable<UserRole>> GetUserRolesAsync(int userId)
        {
            return await _dbContext.UserRoles
                .Where(ur => ur.UserId == userId)
                .ToListAsync();
        }
    }
}
