using JobSearchManagementSystem.Application.Interfaces.Account;
using JobSearchManagementSystem.Domain.Entities.Account;
using JobSearchManagementSystem.Persistance.EntityFrameworks.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Persistance.EntityFrameworks.Repositories
{
    public class EFUserRepository : IUserRepository
    {
        private readonly JobSearchDbContext _dbContext;

        public EFUserRepository(JobSearchDbContext dbContext)
        {
            _dbContext = dbContext;
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

        public async Task<User?> GetByIdAsync(int userId)
        {
            return await _dbContext.Set<User>()
                 .Include(x => x.UserDetail)
                 .Include(x => x.UserRoles)
                 .ThenInclude(ur => ur.Role) // Include the Role if needed
                 .FirstOrDefaultAsync(x => x.Id == userId);
        }

        public async Task UpdateUser(User user)
        {
            // Attach the entity if it's not being tracked
            var existingUser = await _dbContext.Set<User>().FindAsync(user.Id);

            if (existingUser != null)
            {
                // Update the existing user with new values
                _dbContext.Entry(existingUser).CurrentValues.SetValues(user);

                // Optionally, update related entities if necessary
                if (user.UserDetail != null)
                {
                    var existingUserDetail = await _dbContext.Set<UserDetail>()
                        .FirstOrDefaultAsync(ud => ud.UserId == user.Id);

                    if (existingUserDetail != null)
                    {
                        _dbContext.Entry(existingUserDetail).CurrentValues.SetValues(user.UserDetail);
                    }
                }

                // Save changes to the database
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _dbContext.Users
                .Include(x => x.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .Include(x => x.UserDetail)
                .ToListAsync();
        }

    }
}
