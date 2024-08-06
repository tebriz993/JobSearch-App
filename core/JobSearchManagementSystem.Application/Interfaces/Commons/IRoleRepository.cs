using JobSearchManagementSystem.Domain.Entities.Account;
using MediatR;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Application.Interfaces.Commons
{
    public interface IRoleRepository:IRequest<Role>
    {
        Task AddAsync(Role role);
        Task UpdateAsync(Role role);
        Task DeleteAsync(Role role);
        Task<IEnumerable<Role>> GetAllAsync();
        Task<Role> GetByIdAsync(int ıd);
    }
}
