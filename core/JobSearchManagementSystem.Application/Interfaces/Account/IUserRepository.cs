using JobSearchManagementSystem.Domain.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Application.Interfaces.Account
{
    public interface IUserRepository
    {
        Task AddUser(User user);

        Task UpdateUser(User user);

        Task<User?> GetUserWithDetail(string email);
        Task<User?> GetByIdAsync(int userId);
        Task<IEnumerable<User>> GetAllAsync();
    }
}
